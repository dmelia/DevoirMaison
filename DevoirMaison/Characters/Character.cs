using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using DevoirMaison.Combat;
using Timer = System.Timers.Timer;

namespace DevoirMaison.Characters
{
    public abstract class Character
    {
        private static int _poisonCooldown = 5000;
        public BattleGround battleGround { get; set; }
        public string Name { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public double AttackSpeed { get; set; }

        public int Damages { get; set; }

        public int MaximumLife { get; set; }

        public int CurrentLife { get; set; }

        public double PowerSpeed { get; set; }

        public int AttackCooldown { get; set; }

        public int PoisonCounter { get; set; }

        public CharacterType CharacterType { get; set; }

        public HeroDamage HeroDamage { get; set; } = new();

        public bool IsDead { get; set; } = false;

        public bool IsCorpseConsumed { get; set; } = false;

        public bool IsClone { get; set; } = false;

        public bool IsImmuneToPoison { get; set; } = false;

        public CharacterStatus CharacterStatus { get; set; } = CharacterStatus.Normal;

        public abstract void SpecialPower();

        public virtual void TargetCharacterAndAttack()
        {
            Character target = battleGround.FindFirstTarget(false, this, false);
            int attackValue = RollAttack();
            int damageTaken = target.TakeAttackDamage(attackValue, HeroDamage, false);
            Console.WriteLine("{0} attacked {1}, dealt {2} damage", Name, target.Name, damageTaken);
        }

        public virtual int RollAttack()
        {
            return Attack + DiceService.RollDice(1, 100);
        }

        public virtual int RollDefense()
        {
            return Defense + DiceService.RollDice(1, 100);
        }

        public virtual int RollAttackSpeed()
        {
            return (int) (Math.Ceiling(1000 / AttackSpeed) - DiceService.RollDice(1, 100));
        }

        public int GetPowerDelay()
        {
            return (int) Math.Ceiling(1000 / PowerSpeed);
        }

        public void GainLife(int amount)
        {
            CurrentLife += amount;
            if (CurrentLife > MaximumLife)
            {
                CurrentLife = MaximumLife;
            }
        }

        public void TakeDamage(int amount)
        {
            CurrentLife -= amount;
            if (CurrentLife <= 0)
            {
                Console.WriteLine("{0} died !", Name);
                IsDead = true;
            }
        }

        //Returns the amount of damage taken (after defense reduction)
        public int TakeAttackDamage(int amount, HeroDamage heroDamage, bool canCritical)
        {
            //todo : fix, currently characters never take damage
            int defenseRoll = RollDefense();
            int damageTaken = (int) Math.Ceiling((double) ((amount - defenseRoll) * (Damages / 100)));
            if (IsClone)
            {
                //If hit and takes damage, double is destroyed
                if (defenseRoll < amount)
                {
                    IsDead = true;
                    //Doubles leave no exploitable corpses
                    IsCorpseConsumed = true;
                    //Defense was unsuccessful
                    return damageTaken;
                }
            }

            if (defenseRoll < amount)
            {
                //Only take damage if it is a positive value, if defense roll was higher, no damage is taken
                if (damageTaken > 0)
                {
                    int poisonAmount = (int) Math.Ceiling(damageTaken * heroDamage.PoisonDamagePercentage);
                    int normalDamage = (int) Math.Ceiling(damageTaken * heroDamage.NormalDamagePercentage);
                    int sacredDamage = (int) Math.Ceiling(damageTaken * heroDamage.SacredDamagePercentage);

                    if (!IsImmuneToPoison)
                    {
                        //Take poison damage
                        PoisonCounter += poisonAmount;
                        CharacterStatus = CharacterStatus.Poisoned;
                    }

                    //Take normal damage
                    TakeDamage(normalDamage);
                    if (CharacterType == CharacterType.Undead)
                    {
                        //Multiply sacred damage by 2 if character is undead
                        sacredDamage = sacredDamage * 2;
                    }

                    //Take sacred damage
                    TakeDamage(sacredDamage);

                    //Apply attack cooldown
                    AddAttackCooldown(sacredDamage + poisonAmount + normalDamage);

                    //For Assassin criticals
                    if (canCritical)
                    {
                        if (normalDamage >= CurrentLife / 2)
                        {
                            CurrentLife = 0;
                            IsDead = true;
                        }
                    }

                    //Defense was unsuccessful
                    return damageTaken;
                }
            }

            //Defense was successful
            return 0;
        }

        public virtual void AddAttackCooldown(int amount)
        {
            var attackCooldown = AttackCooldown;
            Interlocked.Add(ref attackCooldown, amount);
        }


        private Timer _timer;

        public virtual void StartLife()
        {
            Console.WriteLine("{0} is joining the fight ! The character is a {1} {2}", Name, CharacterType,
                this.GetType().Name);
            _timer = new Timer();
            _timer.Elapsed += (_, _) =>
            {
                if (IsDead) _timer.Stop();
            };
            _timer.Elapsed += AttackElapsedHandler;
            _timer.Elapsed += PowerElapsedHandler;
            _timer.Elapsed += PoisonedElapsedHandler;
            _timer.Enabled = true;
        }

        public void AttackElapsedHandler(object source, ElapsedEventArgs args)
        {
            Task.Run(() =>
            {
                Task.Delay(AttackCooldown);
                //Attack
                TargetCharacterAndAttack();

                //Roll attack delay
                AttackCooldown = RollAttackSpeed();
            });
        }

        public void PowerElapsedHandler(object source, ElapsedEventArgs args)
        {
            //Use power
            Task.Run(() =>
            {
                Task.Delay(GetPowerDelay());
                SpecialPower();
            });
        }

        public void PoisonedElapsedHandler(object source, ElapsedEventArgs args)
        {
            //Take Poison Damage if poisoned
            Task.Run(() =>
            {
                if (CharacterStatus == CharacterStatus.Poisoned)
                {
                    Task.Delay(_poisonCooldown);
                    TakeDamage(PoisonCounter);
                }
            });
        }

        public static int TimeDifferenceFromNow(DateTime start)
        {
            DateTime now = DateTime.Now;
            TimeSpan span = now - start;
            return (int) span.TotalMilliseconds;
        }
    }
}
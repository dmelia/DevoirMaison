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

        public HeroDamage HeroDamage { get; set; }

        public bool IsDead { get; set; } = false;

        public bool IsCorpseConsumed { get; set; } = false;

        public bool IsClone { get; set; } = false;

        public bool IsImmuneToPoison { get; set; } = false;

        public CharacterStatus CharacterStatus { get; set; } = CharacterStatus.Normal;

        public abstract void SpecialPower();

        public virtual void TargetCharacterAndAttack()
        {
            //todo
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

        public virtual void TakeDamage(int amount)
        {
            CurrentLife -= amount;
            if (CurrentLife <= 0)
            {
                IsDead = true;
            }
        }

        //Returns true if 50% or more of this characters HP was lost from attack (for Assassin critical hit)
        public virtual bool TakeAttackDamage(int amount, HeroDamage heroDamage)
        {
            int defenseRoll = RollDefense();
            if (IsClone)
            {
                //If hit and takes damage, double is destroyed
                if (defenseRoll < amount)
                {
                    IsDead = true;
                    //Doubles leave no exploitable corpses
                    IsCorpseConsumed = true;
                }
            }
            
            if (defenseRoll < amount)
            {
                int damageTaken = (int) Math.Ceiling((double) ((amount - defenseRoll) * (Damages / 100)));
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
                    
                    //Returns true if critical hit
                    return normalDamage >= CurrentLife / 2;
                }
            }
            //Return false by default
            return false;
        }

        public virtual void AddAttackCooldown(int amount)
        {
            var attackCooldown = AttackCooldown;
            Interlocked.Add(ref attackCooldown, amount);
        }


        private Timer _timer;

        public void StartLife()
        {
            Console.WriteLine("{0} is joining the fight ! The character is a {1} {2}", Name, CharacterType,
                this.GetType().Name);
            _timer = new Timer();
            _timer.AutoReset = false;
            _timer.Elapsed += (_, _) =>
            {
                if (IsDead) _timer.Stop();
            };
            _timer.Elapsed += AttackElapsedHandler;
            _timer.Elapsed += PowerElapsedHandler;
            _timer.Elapsed += PoisonedElapsedHandler;
        }

        public async void AttackElapsedHandler(object source, ElapsedEventArgs args)
        {
            await Task.Run(() =>
            {
                Task.Delay(AttackCooldown);
                //Attack
                TargetCharacterAndAttack();

                //Roll attack delay
                AttackCooldown = RollAttackSpeed();
            });
        }

        public async void PowerElapsedHandler(object source, ElapsedEventArgs args)
        {
            //Use power
            await Task.Run(() =>
            {
                Task.Delay(GetPowerDelay());
                SpecialPower();
            });
        }

        public async void PoisonedElapsedHandler(object source, ElapsedEventArgs args)
        {
            //Take Poison Damage if poisoned
            await Task.Run(() =>
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
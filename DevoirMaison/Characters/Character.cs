using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using DevoirMaison.Combat;
using Timer = System.Timers.Timer;

namespace DevoirMaison.Characters
{
    public delegate void DeathEventHandler(Object sender, DeathEventArgs e);
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

        private int _attackCooldownAmount = 0;

        private bool _deathMessageSaid = false;

        public CharacterStatus CharacterStatus { get; set; } = CharacterStatus.Normal;

        public abstract void SpecialPower();

        public virtual void TargetCharacterAndAttack()
        {
            if (!IsDead)
            {
                Character target = battleGround.FindTarget(false, this, false);
                int attackValue = RollAttack();
                int damageTaken = target.TakeAttackDamage(attackValue, HeroDamage, false);
                if (damageTaken > 0)
                {
                    Console.WriteLine("{0} attacked {1}, dealt {2} damage", Name, target.Name, damageTaken);
                }
                else
                {
                    Console.WriteLine("{0} attacked {1}, but it was blocked", Name, target.Name);
                } 
            }
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
            return (int) (1000 / AttackSpeed) - DiceService.RollDice(1, 100);
        }

        public int GetPowerDelay()
        {
            return (int) (1000 / PowerSpeed);
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
            if (CurrentLife <= 0 && !_deathMessageSaid)
            {
                _deathMessageSaid = true;
                Console.WriteLine("{0} died !", Name);
                IsDead = true;
                DeathEventArgs args = new DeathEventArgs();
                OnCharacterDead(args);
            }
        }

        //Returns the amount of damage taken (after defense reduction)
        public int TakeAttackDamage(int amount, HeroDamage heroDamage, bool canCritical)
        {
            int defenseRoll = RollDefense();
            double damageReduction = (double) Damages / 100.0;
            int damageTaken;
            //Deal with zombie having 0 defense
            if (damageReduction > 0)
            {
                damageTaken = (int) ((amount - defenseRoll) * damageReduction);
            }
            else
            {
                damageTaken = amount - defenseRoll;
            }

            if (IsClone)
            {
                //If hit and takes damage, double is destroyed
                if (defenseRoll < amount)
                {
                    IsDead = true;
                    Console.WriteLine("{0} clone died !", Name);
                    //Doubles leave no exploitable corpses
                    IsCorpseConsumed = true;
                    //Defense was unsuccessful
                    DeathEventArgs args = new DeathEventArgs();
                    OnCharacterDead(args);
                    return damageTaken;
                }
            }

            if (defenseRoll < amount)
            {
                //Only take damage if it is a positive value, if defense roll was higher, no damage is taken
                //Lose stealth if character was hidden
                if (CharacterStatus == CharacterStatus.Hidden) CharacterStatus = CharacterStatus.Normal;
                int poisonAmount = (int) (damageTaken * heroDamage.PoisonDamagePercentage);
                int normalDamage = (int) (damageTaken * heroDamage.NormalDamagePercentage);
                int sacredDamage = (int) (damageTaken * heroDamage.SacredDamagePercentage);

                if (!IsImmuneToPoison && poisonAmount > 0)
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
                        Console.WriteLine("{0} died from a critical hit !", Name);
                        DeathEventArgs args = new DeathEventArgs();
                        OnCharacterDead(args);
                    }
                }

                //Defense was unsuccessful
                return damageTaken;
            }

            //Defense was successful
            return 0;
        }

        public virtual void AddAttackCooldown(int amount)
        {
            _attackCooldownAmount += amount;
        }


        public virtual void StartLife()
        {
            Console.WriteLine("{0} is joining the fight ! {1} is a {2}", Name, CharacterType,
                GetType().Name);
            Timer powerTimer = new Timer(GetPowerDelay());
            powerTimer.Elapsed += DeathHandler;
            powerTimer.Elapsed += PowerElapsedHandler;
            Timer poisonTimer = new Timer(_poisonCooldown);
            poisonTimer.Elapsed += DeathHandler;
            poisonTimer.Elapsed += PoisonedElapsedHandler;

            powerTimer.Enabled = true;
            poisonTimer.Enabled = true;
            AttackHandler();
        }

        public void DeathHandler(object source, ElapsedEventArgs args)
        {
            if (IsDead || !battleGround.ArePlayersFighting())
            {
                Timer changeType = source as Timer;
                changeType?.Stop();
            }
        }

        public void AttackHandler()
        {
            Task.Run(async () =>
                {
                    while (!IsDead && battleGround.ArePlayersFighting())
                    {
                        await Task.Delay(_attackCooldownAmount + AttackCooldown);
                        _attackCooldownAmount = 0;
                        AttackAction();
                    }
                });
        }

        private void AttackAction()
        {
            //Lose stealth if character was hidden
            if (CharacterStatus == CharacterStatus.Hidden) CharacterStatus = CharacterStatus.Normal;

            //Attack
            TargetCharacterAndAttack();

            //Roll attack delay
            AttackCooldown = RollAttackSpeed();
        }

        public void PowerElapsedHandler(object source, ElapsedEventArgs args)
        {
            if (!IsDead && battleGround.ArePlayersFighting())
            {
                SpecialPower();
            }
        }

        public void PoisonedElapsedHandler(object source, ElapsedEventArgs args)
        {
            if (!IsDead && battleGround.ArePlayersFighting() && CharacterStatus == CharacterStatus.Poisoned)
            {
                Console.WriteLine("{0} took {1} poison damage !", Name, PoisonCounter);
                TakeDamage(PoisonCounter);
            }
        }

        public static int TimeDifferenceFromNow(DateTime start)
        {
            DateTime now = DateTime.Now;
            TimeSpan span = now - start;
            return (int) span.TotalMilliseconds;
        }
        
        #region Death event

        public event DeathEventHandler Death;

        protected void OnCharacterDead(DeathEventArgs e)
        {
            DeathEventHandler handler = Death;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
    }
}

using System;
using System.Timers;
using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    public abstract class Character
    {
        private static int _poisonCooldown = 5000;
        public BattleGround battleGround { get; set; }
        public string Name { get; set; }

        public DamageType BaseDamageType { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public double AttackSpeed { get; set; }

        public int Damages { get; set; }

        public int MaximumLife { get; set; }

        public int CurrentLife { get; set; }

        public double PowerSpeed { get; set; }

        public DateTime LastAttackDate { get; set; }

        public DateTime LastPowerDate { get; set; }

        public int AttackCooldown { get; set; }

        public int PowerCooldown { get; set; }

        public DateTime LastPoisonHitDate { get; set; }

        public int PoisonCounter { get; set; }

        public CharacterType CharacterType { get; set; }

        public bool IsDead { get; set; } = false;

        public bool IsCorpseConsumed { get; set; } = false;

        public bool IsDouble { get; set; } = false;

        public CharacterStatus CharacterStatus { get; set; } = CharacterStatus.Normal;

        public abstract void SpecialPower();

        public abstract void TargetCharacterAndAttack();

        public virtual int RollAttack()
        {
            return Attack + DiceService.RollDice(1, 100);
        }

        public virtual int RollAttackSpeed()
        {
            return (int) (Math.Ceiling(1000 / AttackSpeed) - DiceService.RollDice(1, 100));
        }

        public virtual int GetPowerDelay()
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
                IsDead = true;
            }
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

        public void AttackElapsedHandler(object source, ElapsedEventArgs args)
        {
            if (TimeDifferenceFromNow(LastAttackDate) < AttackCooldown && battleGround.BattleStarted)
            {
                LastAttackDate = DateTime.Now;
                //Attack
                TargetCharacterAndAttack();

                //Roll attack delay
                AttackCooldown = RollAttackSpeed();
            }
        }

        public void PowerElapsedHandler(object source, ElapsedEventArgs args)
        {
            if (TimeDifferenceFromNow(LastPowerDate) < PowerCooldown && battleGround.BattleStarted)
            {
                //Set latest power use date
                LastPowerDate = DateTime.Now;

                //Use power
                SpecialPower();

                //Set power delay in milliseconds
                PowerCooldown = GetPowerDelay();
            }
        }

        public void PoisonedElapsedHandler(object source, ElapsedEventArgs args)
        {
            if (CharacterStatus == CharacterStatus.Poisoned && battleGround.BattleStarted)
            {
                if (TimeDifferenceFromNow(LastPoisonHitDate) < _poisonCooldown)
                {
                    TakeDamage(PoisonCounter);
                    LastPoisonHitDate = DateTime.Now;
                }
            }
        }

        public static int TimeDifferenceFromNow(DateTime start)
        {
            DateTime now = DateTime.Now;
            TimeSpan span = now - start;
            return (int) span.TotalMilliseconds;
        }
    }
}
using System;
using System.Timers;
using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    public abstract class Character
    {
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

        public virtual int RollAttack()
        {
            return Attack + DiceService.RollDice(1, 100);
        }

        public virtual int RollSpeed()
        {
            return (int) (Math.Ceiling(1000 / AttackSpeed) - DiceService.RollDice(1, 100));
        }

        public void GainLife(int amount)
        {
            CurrentLife += amount;
            if (CurrentLife > MaximumLife)
            {
                CurrentLife = MaximumLife;
            }
        }


        private static Timer timer;

        public void StartLife()
        {
            Console.WriteLine("{0} is joining the fight ! The character is a {1} {2}", Name, CharacterType,
                this.GetType().Name);
            timer = new Timer();
            timer.AutoReset = false;
            timer.Elapsed += (sender, args) =>
            {
                if (IsDead) timer.Stop();
            };
        }
    }
}
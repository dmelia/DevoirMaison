using System;

namespace DevoirMaison
{
    //Slappy boi
    public class Berserker : Character
    {
        private double BasePowerSpeed = 1;
        private int BaseAttack = 50;
        private int BaseDamages = 20;

        public Berserker(string name)
        {
            Name = name;
            Defense = 50;
            AttackSpeed = 1.1;
            Damages = BaseDamages;
            MaximumLife = 400;
            CurrentLife = 400;
            Attack = BaseAttack;
            PowerSpeed = BasePowerSpeed;
            _DamageType = DamageType.Normal;
        }

        public override void SpecialPower()
        {
            Console.WriteLine("Slappy boi gets stronger!");
            var lifePercentageLost = Math.Floor((CurrentLife - MaximumLife) * (double) MaximumLife / 10);
            PowerSpeed = BasePowerSpeed + 0.3 * (lifePercentageLost);
            int lifeLost = MaximumLife - CurrentLife;
            if (lifeLost > 0)
            {
                int valueAdded = (int) Math.Ceiling((double) (lifeLost / 2));
                Damages = BaseDamages + valueAdded;
                Attack = BaseAttack + valueAdded;
            }
        }

        public override void ReceiveDamage(float percentageValue, int flatValue, DamageType damageType)
        {
            throw new System.NotImplementedException();
        }

        public override int RollAttack()
        {
            throw new System.NotImplementedException();
        }

        public override float RollSpeed()
        {
            throw new System.NotImplementedException();
        }

        public override int RollAttackDelay()
        {
            throw new NotImplementedException();
        }
    }
}
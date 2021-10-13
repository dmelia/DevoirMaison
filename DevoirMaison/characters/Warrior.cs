namespace DevoirMaison
{
    public class Warrior: Character
    {
        public Warrior(string name)
        { 
            Name = name;
            Defense = 0;
            AttackSpeed = 1;
            Damages = 20;
            MaximumLife = 1500;
            CurrentLife = 1500;
            Attack = 150;
            PowerSpeed = 0.1;
            _DamageType = DamageType.Normal;
        }

        public override void SpecialPower()
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }
    }
}
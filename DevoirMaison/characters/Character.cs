namespace DevoirMaison
{
    public abstract class Character
    {
        public string Name { get; set; }

        public DamageType _DamageType { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public double AttackSpeed { get; set; }

        public int Damages { get; set; }

        public int MaximumLife { get; set; }

        public int CurrentLife { get; set; }

        public double PowerSpeed { get; set; }

        public abstract void SpecialPower();

        public abstract void ReceiveDamage(float percentageValue, int flatValue, DamageType damageType);

        public abstract int RollAttack();

        public abstract float RollSpeed();

        public abstract int RollAttackDelay();
    }
}
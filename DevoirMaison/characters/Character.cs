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

        public bool IsDead { get; set; } = false;

        public bool IsDouble { get; set; } = false;

        public CharacterType _CharacterType { get; set; }

        public CharacterStatus _CharacterStatus { get; set; } = CharacterStatus.Normal;

        public abstract void SpecialPower(BattleGround battleGround);

        // Returns true if hit succeeded
        public abstract bool ReceiveDamage(Damage damage);

        public abstract int RollAttack();

        public abstract float RollSpeed();

        public abstract int RollAttackDelay();

        public abstract Character TargetCharacterAndAttack(BattleGround battleGround);
    }
}
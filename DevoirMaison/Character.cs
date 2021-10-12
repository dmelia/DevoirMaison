namespace DevoirMaison
{
    public abstract class Character
    {
        public string Type
        {
            get;
            set;
        }

        public int Attack
        {
            get;
            set;
        }
        
        public int Defense
        {
            get;
            set;
        }
        
        public float AttackSpeed
        {
            get;
            set;
        }
        
        public int Damages
        {
            get;
            set;
        }
        
        public int MaximumLife
        {
            get;
            set;
        }
        
        public int CurrentLife
        {
            get;
            set;
        }
        
        public float PowerSpeed
        {
            get;
            set;
        }

        public Character(string type, int attack, int defense, float attackSpeed, int damages, int maximumLife, int currentLife, float powerSpeed)
        {
            Type = type;
            Attack = attack;
            Defense = defense;
            AttackSpeed = attackSpeed;
            Damages = damages;
            MaximumLife = maximumLife;
            CurrentLife = currentLife;
            PowerSpeed = powerSpeed;
        }
        
        public abstract void SpecialPower();
        public abstract void SpecialPassive();
        public abstract void ReceiveDamage(float percentageValue, int flatValue, DamageType damageType);
    }
}
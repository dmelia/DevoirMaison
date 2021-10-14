namespace DevoirMaison
{
    public class Damage
    {
        public int Amount { get; set; }
        public DamageType _DamageType { get; set; }
        public bool IsPercentageValue { get; set; }
        public double percentageAmount { get; set; }

        public Damage(int amount, DamageType damageType, bool isPercentageValue, double percentageAmount)
        {
            Amount = amount;
            _DamageType = damageType;
            IsPercentageValue = isPercentageValue;
            this.percentageAmount = percentageAmount;
        }
    }
}
namespace DevoirMaison
{
    //Pally boi
    public class Paladin : Character
    {
        public Paladin(string name)
        {
            Name = name;
            Attack = 60;
            Defense = 145;
            AttackSpeed = 1.6;
            Damages = 40;
            MaximumLife = 250;
            CurrentLife = 250;
            PowerSpeed = 0.5;
            _DamageType = DamageType.Sacred;
            _CharacterType = CharacterType.Human;
        }

        public override void SpecialPower(BattleGround battleGround)
        {
            //Reduces delay to 0 of next hit
            throw new System.NotImplementedException();
        }

        public override bool ReceiveDamage(Damage damage)
        {
            throw new System.NotImplementedException();
        }

        public override int RollAttack()
        {
            //Deals sacred damage
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

        public override Character TargetCharacterAndAttack(BattleGround battleGround)
        {
            throw new System.NotImplementedException();
        }
    }
}
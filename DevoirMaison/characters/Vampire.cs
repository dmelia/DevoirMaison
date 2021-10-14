namespace DevoirMaison
{
    //Sucky boi
    public class Vampire : Character
    {
        public Vampire(string name)
        {
            Name = name;
            Attack = 125;
            Defense = 125;
            AttackSpeed = 2;
            Damages = 50;
            MaximumLife = 150;
            CurrentLife = 150;
            PowerSpeed = 0.2;
            _DamageType = DamageType.Normal;
            _CharacterType = CharacterType.Undead;
        }

        public override void SpecialPower(BattleGround battleGround)
        {
            //Selects a random target and increases its attack delay of an amount equal to damage that the sucky boi received since the last sue of his power
            throw new System.NotImplementedException();
        }

        public override bool ReceiveDamage(Damage damage)
        {
            //Double damage from Sacred
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

        public override Character TargetCharacterAndAttack(BattleGround battleGround)
        {
            //Sucky boi heals himself for 50% of damage dealt to target
            throw new System.NotImplementedException();
        }
    }
}
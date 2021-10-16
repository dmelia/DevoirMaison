namespace DevoirMaison
{
    //Bloody boi
    public class Vampire : Character
    {
        public Vampire(string name, BattleGround battleGround)
        {
            Name = name;
            Attack = 125;
            Defense = 125;
            AttackSpeed = 2;
            Damages = 50;
            MaximumLife = 150;
            CurrentLife = 150;
            PowerSpeed = 0.2;
            DamageType = DamageType.Normal;
            CharacterType = CharacterType.Undead;
            base.battleGround = battleGround;
        }

        public override void SpecialPower()
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

        public override int RollSpeed()
        {
            throw new System.NotImplementedException();
        }

        public override Character TargetCharacterAndAttack()
        {
            //Bloody boi heals himself for 50% of damage dealt to target
            throw new System.NotImplementedException();
        }
    }
}
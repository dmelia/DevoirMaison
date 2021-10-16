namespace DevoirMaison
{
    //Lighty boi
    public class Priest : Character
    {
        public Priest(string name, BattleGround battleGround)
        {
            Name = name;
            Attack = 100;
            Defense = 125;
            AttackSpeed = 1.5;
            Damages = 90;
            MaximumLife = 150;
            CurrentLife = 150;
            PowerSpeed = 1.0;
            DamageType = DamageType.Sacred;
            CharacterType = CharacterType.Human;
            base.battleGround = battleGround;
            
        }

        public override void SpecialPower()
        {
            //Lighty boi heals himself for 10% of his max life
            throw new System.NotImplementedException();
        }

        public override bool ReceiveDamage(Damage damage)
        {
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
            //Targets undead in priority
            //Deals sacred damage
            throw new System.NotImplementedException();
        }
    }
}
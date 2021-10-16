namespace DevoirMaison
{
    //Dodgy boi
    public class Assassin : Character
    {
        public Assassin(string name, BattleGround battleGround)
        {
            Name = name;
            Attack = 150;
            Defense = 100;
            AttackSpeed = 1;
            Damages = 100;
            MaximumLife = 185;
            CurrentLife = 185;
            PowerSpeed = 0.5;
            DamageType = DamageType.Sacred;
            CharacterType = CharacterType.Human;
            base.battleGround = battleGround;
        }

        public override void SpecialPower()
        {
            CharacterStatus = CharacterStatus.Hidden;
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
            //Passive : attacks by the Dodgy boi deal 100% normal damage and 10% poison damage
            //If the Dodgy boi deals more than half of the targets life in damage, a critical hit is inflicted, killing the enemy
            throw new System.NotImplementedException();
        }
    }
}
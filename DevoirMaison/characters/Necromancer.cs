namespace DevoirMaison
{
    public class Necromancer : Character 
    {
        //Bony boi
        public Necromancer(string name, BattleGround battleGround)
        {
            Name = name;
            Attack = 0;
            Defense = 10;
            AttackSpeed = 1;
            Damages = 0;
            MaximumLife = 275;
            CurrentLife = 275;
            PowerSpeed = 5;
            DamageType = DamageType.Normal;
            CharacterType = CharacterType.Undead;
            base.battleGround = battleGround;
        }

        public override void SpecialPower()
        {
            //If no one is dead, gain camouflage
            
            //Each time a fighter dies, the bony boi gains 5 attack/5 defense/50 life/50 max life
            throw new System.NotImplementedException();
        }

        public override bool ReceiveDamage(Damage damage)
        {
            //Double damage from Sacred
            throw new System.NotImplementedException();
        }

        public override int RollAttack()
        {
            //rolls are 1-150
            throw new System.NotImplementedException();
        }

        public override int RollSpeed()
        {
            //rolls are 1-150
            throw new System.NotImplementedException();
        }

        public override Character TargetCharacterAndAttack()
        {
            //Deals 50% normal damage, 50% poison damage
            throw new System.NotImplementedException();
        }
    }
}
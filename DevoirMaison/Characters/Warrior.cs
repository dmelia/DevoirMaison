using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    //Hitty boi
    public class Warrior: Character
    {
        public Warrior(string name, BattleGround battleGround)
        { 
            Name = name;
            Defense = 0;
            AttackSpeed = 1;
            Damages = 20;
            MaximumLife = 1500;
            CurrentLife = 1500;
            Attack = 150;
            PowerSpeed = 0.1;
            BaseDamageType = DamageType.Normal;
            CharacterType = CharacterType.Human;
            base.battleGround = battleGround;
        }

        public override void SpecialPower()
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
    }
}
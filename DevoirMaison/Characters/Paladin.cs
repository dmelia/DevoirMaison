using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    //Pally boi
    public class Paladin : Character
    {
        public Paladin(string name, BattleGround battleGround)
        {
            Name = name;
            Attack = 60;
            Defense = 145;
            AttackSpeed = 1.6;
            Damages = 40;
            MaximumLife = 250;
            CurrentLife = 250;
            PowerSpeed = 0.5;
            BaseDamageType = DamageType.Sacred;
            CharacterType = CharacterType.Human;
            base.battleGround = battleGround;
        }

        public override void SpecialPower()
        {
            //Reduces delay to 0 of next hit
            throw new System.NotImplementedException();
        }

        public override int RollAttack()
        {
            //Deals sacred damage
            throw new System.NotImplementedException();
        }

        public override int RollSpeed()
        {
            throw new System.NotImplementedException();
        }
    }
}
using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    //Brainy boi
    public class Magician : Character
    {
        public Magician(string name, BattleGround battleGround)
        {
            Name = name;
            Attack = 75;
            Defense = 125;
            AttackSpeed = 1.5;
            Damages = 100;
            MaximumLife = 125;
            CurrentLife = 125;
            PowerSpeed = 0.1;
            BaseDamageType = DamageType.Normal;
            CharacterType = CharacterType.Human;
            base.battleGround = battleGround;
        }

        public override void SpecialPower()
        {
            //Special is an attack
            //Targets multiple enemies
            //When it hits 1st enemy, damage is reduced by 10% (from total initial damage)
            //After hit, targets another enemy
            //continues hitting enemies and reducing damage by 10% until damage is 0 or that a player was able to defend.
            //If 1st target was able to defend, it does not chain
            //Initial damage is attack damage multiplied by 5
            throw new System.NotImplementedException();
        }

        public override void TargetCharacterAndAttack()
        {
            throw new System.NotImplementedException();
        }
    }
}
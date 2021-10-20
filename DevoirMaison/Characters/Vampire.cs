using DevoirMaison.Combat;

namespace DevoirMaison.Characters
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
            CharacterType = CharacterType.Undead;
            base.battleGround = battleGround;
            HeroDamage.NormalDamagePercentage = 1;
        }

        public override void SpecialPower()
        {
            //Selects a random target and increases its attack delay of an amount equal to damage that the sucky boi received since the last sue of his power
            throw new System.NotImplementedException();
        }

        public override void TargetCharacterAndAttack()
        {
            //Bloody boi heals himself for 50% of damage dealt to target
            throw new System.NotImplementedException();
        }
        //Double damage from Sacred
        
    }
}
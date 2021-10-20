using DevoirMaison.Combat;

namespace DevoirMaison.Characters
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
            CharacterType = CharacterType.Undead;
            base.battleGround = battleGround;
            //Deals 50% normal damage, 50% poison damage
            HeroDamage.NormalDamagePercentage = 0.5;
            HeroDamage.PoisonDamagePercentage = 0.5;
        }

        public override void SpecialPower()
        {
            //If no one is dead, gain camouflage
            
            //Each time a fighter dies, the bony boi gains 5 attack/5 defense/50 life/50 max life
            throw new System.NotImplementedException();
        }

        public override void TargetCharacterAndAttack()
        {
            throw new System.NotImplementedException();
        }

        public override int RollAttack()
        {
            //rolls are 1-150
            throw new System.NotImplementedException();
        }

        public override int RollAttackSpeed()
        {
            //rolls are 1-150
            throw new System.NotImplementedException();
        }
    }
}
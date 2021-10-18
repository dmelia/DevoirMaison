using System;
using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    //Hitty boi
    public class Warrior: Character
    {
        private readonly double BaseAttackSpeed = 2.2;
        private DateTime PreviousBuffTime;
        public Warrior(string name, BattleGround battleGround)
        { 
            Name = name;
            Defense = 105;
            AttackSpeed = BaseAttackSpeed;
            Damages = 150;
            MaximumLife = 250;
            CurrentLife = 250;
            Attack = 150;
            PowerSpeed = 0.2;
            BaseDamageType = DamageType.Normal;
            CharacterType = CharacterType.Human;
            base.battleGround = battleGround;
        }

        public override void SpecialPower()
        {
            if (TimeDifferenceFromNow(PreviousBuffTime) < 3000)
            {
                Console.Write("We purposely trained {0} wrong, as a joke !", Name);
                Console.Write("{0} Attacks faster !");
                AttackSpeed = BaseAttackSpeed + 0.5;
                PreviousBuffTime = DateTime.Now;
            }
        }

        public override void TargetCharacterAndAttack()
        {
            throw new System.NotImplementedException();
        }
    }
}
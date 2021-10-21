using System;
using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    //Hitty boi
    public class Warrior : Character
    {
        private readonly double BaseAttackSpeed = 2.2;

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
            CharacterType = CharacterType.Human;
            base.battleGround = battleGround;
            HeroDamage.NormalDamagePercentage = 1;
        }

        public override void SpecialPower()
        {
            //Todo remove buff after 3 seconds
            Console.Write("We purposely trained {0} wrong, as a joke !", Name);
            Console.Write("{0} Attacks faster !");
            AttackSpeed = BaseAttackSpeed + 0.5;
        }
    }
}
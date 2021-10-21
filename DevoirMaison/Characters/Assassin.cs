using System;
using DevoirMaison.Combat;

namespace DevoirMaison.Characters
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
            CharacterType = CharacterType.Human;
            base.battleGround = battleGround;
            //Attacks by the dodgy boi deal 100% normal damage and 10% poison damage
            HeroDamage.NormalDamagePercentage = 1;
            HeroDamage.PoisonDamagePercentage = 0.1;
        }

        public override void SpecialPower()
        {
            if (CharacterStatus != CharacterStatus.Poisoned)
            {
                //Cannot become hidden if poisoned
                Console.WriteLine("Dodgy boi becomes hidden !");
                CharacterStatus = CharacterStatus.Hidden;
            }
        }
    }
}
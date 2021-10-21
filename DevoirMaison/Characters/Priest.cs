using System;
using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    //Lighty boi
    public class Priest : Character
    {
        public Priest(string name, BattleGround battleGround)
        {
            Name = name;
            Attack = 100;
            Defense = 125;
            AttackSpeed = 1.5;
            Damages = 90;
            MaximumLife = 150;
            CurrentLife = 150;
            PowerSpeed = 1.0;
            CharacterType = CharacterType.Human;
            base.battleGround = battleGround;
            //Deals sacred damage
            HeroDamage.SacredDamagePercentage = 1;
        }

        public override void SpecialPower()
        {
            //Lighty boi heals himself for 10% of his max life
            GainLife((int) (Math.Ceiling(MaximumLife * 0.1)));
        }

        public override void TargetCharacterAndAttack()
        {
            //Targets undead in priority
            
            throw new System.NotImplementedException();
        }
    }
}
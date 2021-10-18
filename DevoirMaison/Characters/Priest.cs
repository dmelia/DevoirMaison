﻿using DevoirMaison.Combat;

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
            BaseDamageType = DamageType.Sacred;
            CharacterType = CharacterType.Human;
            base.battleGround = battleGround;
            
        }

        public override void SpecialPower()
        {
            //Lighty boi heals himself for 10% of his max life
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


            //Targets undead in priority
            //Deals sacred damage
    }
}
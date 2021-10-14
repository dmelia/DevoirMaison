﻿namespace DevoirMaison
{
    //Hitty boi
    public class Warrior: Character
    {
        public Warrior(string name)
        { 
            Name = name;
            Defense = 0;
            AttackSpeed = 1;
            Damages = 20;
            MaximumLife = 1500;
            CurrentLife = 1500;
            Attack = 150;
            PowerSpeed = 0.1;
            _DamageType = DamageType.Normal;
            _CharacterType = CharacterType.Human;
        }

        public override void SpecialPower(BattleGround battleGround)
        {
            throw new System.NotImplementedException();
        }

        public override bool ReceiveDamage(Damage damage)
        {
            throw new System.NotImplementedException();
        }

        public override int RollAttack()
        {
            throw new System.NotImplementedException();
        }

        public override float RollSpeed()
        {
            throw new System.NotImplementedException();
        }

        public override int RollAttackDelay()
        {
            throw new System.NotImplementedException();
        }

        public override Character TargetCharacterAndAttack(BattleGround battleGround)
        {
            throw new System.NotImplementedException();
        }
    }
}
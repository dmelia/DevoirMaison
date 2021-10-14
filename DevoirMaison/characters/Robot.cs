using System;

namespace DevoirMaison
{
    //Shiny boi
    public class Robot : Character
    {
        
        public Robot(string name)
        {
            Name = name;
            Attack = 25;
            Defense = 100;
            AttackSpeed = 1.2;
            Damages = 50;
            MaximumLife = 275;
            CurrentLife = 275;
            PowerSpeed = 0.5;
            _DamageType = DamageType.Normal;
            _CharacterType = CharacterType.Machine;
        }

        public override void SpecialPower(BattleGround battleGround)
        {
            Console.WriteLine("Robot {0}, increased its attack by 50% !");
            Attack = (int) (Attack + Math.Ceiling(Attack * 0.5));
        }

        public override bool ReceiveDamage(Damage damage)
        {
            //Immune to poison
            throw new System.NotImplementedException();
        }

        public override int RollAttack()
        {
            //Rolls just add 50 to stat
            throw new System.NotImplementedException();
        }

        public override float RollSpeed()
        {
            //Rolls just add 50 to stat
            throw new System.NotImplementedException();
        }

        public override int RollAttackDelay()
        {
            //Rolls just add 50 to stat
            throw new System.NotImplementedException();
        }

        public override Character TargetCharacterAndAttack(BattleGround battleGround)
        {
            throw new NotImplementedException();
        }
    }
}
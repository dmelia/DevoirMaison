using System;
using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    //Shiny boi
    public class Robot : Character
    {
        
        public Robot(string name, BattleGround battleGround)
        {
            Name = name;
            Attack = 25;
            Defense = 100;
            AttackSpeed = 1.2;
            Damages = 50;
            MaximumLife = 275;
            CurrentLife = 275;
            PowerSpeed = 0.5;
            CharacterType = CharacterType.Machine;
            base.battleGround = battleGround;
            HeroDamage.NormalDamagePercentage = 1;
            //Immune to poison
            IsImmuneToPoison = true;
        }

        public override void SpecialPower()
        {
            Console.WriteLine("Boop Beep ! {0}, increased its attack by 50% !", Name);
            Attack = (int) (Attack  * 1.5);
            Console.WriteLine("Attack : {0}", Attack);
        }

        
      

        public override int RollAttack()
        {
            //Rolls just add 50 to stat
            return Attack + 50;
        }

        public override int RollDefense()
        {
            //Rolls just add 50 to stat
            return Defense + 50;
        }

        public override int RollAttackSpeed()
        {
            //Rolls just add 50 to stat
            return (int) ((double) (1000 / AttackSpeed)- 50);
        }
    }
}
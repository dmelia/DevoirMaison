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
            if (!IsDead)
            {
                //Lighty boi heals himself for 10% of his max life
                GainLife((int) (MaximumLife * 0.1));
                Console.WriteLine("{0} healed himself !", Name);
            }
        }

        public override void TargetCharacterAndAttack()
        {
            if (!IsDead)
            {
                //Targets undead in priority
                Character target = battleGround.FindTarget(false, this, true);
                int attackValue = RollAttack();
                int damageTaken = target.TakeAttackDamage(attackValue, HeroDamage, false);
                if (damageTaken > 0)
                {
                    Console.WriteLine("{0} attacked {1}, dealt {2} damage", Name, target.Name, damageTaken);
                }
                else
                {
                    Console.WriteLine("{0} attacked {1}, but it was blocked", Name, target.Name);
                }
            }
        }
    }
}
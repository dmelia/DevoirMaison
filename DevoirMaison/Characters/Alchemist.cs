using System;
using System.Collections.Generic;
using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    //Potion-y boi
    public class Alchemist : Character
    {
        public Alchemist(string name, BattleGround battleGround)
        {
            Name = name;
            Attack = 50;
            Defense = 50;
            AttackSpeed = 1;
            Damages = 30;
            MaximumLife = 150;
            CurrentLife = 150;
            PowerSpeed = 0.1;
            CharacterType = CharacterType.Human;
            base.battleGround = battleGround;
            //100% of damage dealt as poison and 50% of damage dealt as normal
            HeroDamage.SacredDamagePercentage = 0.5;
            HeroDamage.PoisonDamagePercentage = 1;
        }

        public override void SpecialPower()
        {
            //Exchange current life value with highest current life value of any hero in combat
            //After trade, new values of current life cannot exceed maximum life
            Character target = battleGround.FindHighestHealthCharacter();
            int targetsHealth = target.CurrentLife;
            target.CurrentLife = CurrentLife;
            if (target.CurrentLife > target.MaximumLife)
            {
                target.CurrentLife = target.MaximumLife;
            }

            CurrentLife = targetsHealth;
            if (CurrentLife > MaximumLife)
            {
                CurrentLife = MaximumLife;
            }
            Console.WriteLine("Potion-y boi exchanged his life !");
        }

        public override void TargetCharacterAndAttack()
        {
            //All characters have 50% chance to be targeted by the Alchemist's attack
            //All characters are considered as secondary targets (can hit even hidden characters)
            List<Character> targets = battleGround.FindLivingCharacters(this);
            
            foreach (var target in targets)
            {
                if (DiceService.RollDice(0,1) == 1)
                {
                    //Attack character (50% chance)
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

        public override int RollAttack()
        {
            //rolls are 1 - 200
            return Attack + DiceService.RollDice(1, 200);
        }

        public override int RollAttackSpeed()
        {
            //rolls are 1 - 200
            return (int) (double) (1000 / AttackSpeed) - DiceService.RollDice(1, 200);
        }

        public override int RollDefense()
        {
            //rolls are 1 - 200
            return Defense + DiceService.RollDice(1, 200);
        }
    }
}
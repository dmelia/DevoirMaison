using System;
using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    //Brainy boi
    public class Magician : Character
    {
        public Magician(string name, BattleGround battleGround)
        {
            Name = name;
            Attack = 75;
            Defense = 125;
            AttackSpeed = 1.5;
            Damages = 100;
            MaximumLife = 125;
            CurrentLife = 125;
            PowerSpeed = 0.1;
            CharacterType = CharacterType.Human;
            base.battleGround = battleGround;
            HeroDamage.NormalDamagePercentage = 1;
        }

        public override void SpecialPower()
        {
            if (!IsDead)
            {
                //Targets multiple enemies
                //When it hits 1st enemy, damage is reduced by 10% (from total initial damage)
                //After hit, targets another enemy
                //continues hitting enemies and reducing damage by 10% until damage is 0 or that a player was able to defend.
                //If 1st target was able to defend, it does not chain
                //Initial damage is attack damage multiplied by 5
                int initialDamage = RollAttack() * 5;
                Character primaryTarget = battleGround.FindTarget(false, this, false);
                HeroDamage damageTypes = new HeroDamage
                {
                    NormalDamagePercentage = 1
                };
                int damageTaken = primaryTarget.TakeAttackDamage(initialDamage, damageTypes, false);
                bool isSuccessful = damageTaken > 0;
                if (damageTaken > 0)
                    Console.WriteLine("{0} shocked {1} for {2} damage !", Name, primaryTarget.Name, damageTaken);
                if (isSuccessful)
                {
                    do
                    {
                        initialDamage = (int) (initialDamage * 0.9);
                        Character secondaryTarget = battleGround.FindTarget(true, this, false);
                        damageTaken = secondaryTarget.TakeAttackDamage(initialDamage, damageTypes, false);
                        isSuccessful = damageTaken > 0;
                        if (damageTaken > 0)
                            Console.WriteLine("{0} shocked {1} for {2} damage !", Name, primaryTarget.Name,
                                damageTaken);
                    } while (isSuccessful || initialDamage > 0);
                }
            }
        }
    }
}
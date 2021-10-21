using System;
using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    //Bony boi
    public class Necromancer : Character
    {
        private int BaseAttack = 0;
        private int BaseDefense = 10;
        private int BaseMaximumLife = 275;
        
        public Necromancer(string name, BattleGround battleGround)
        {
            Name = name;
            Attack = BaseAttack;
            Defense = BaseDefense;
            AttackSpeed = 1;
            Damages = 0;
            MaximumLife = BaseMaximumLife;
            CurrentLife = BaseMaximumLife;
            PowerSpeed = 5;
            //Double damage from Sacred
            CharacterType = CharacterType.Undead;
            base.battleGround = battleGround;
            //Deals 50% normal damage, 50% poison damage
            HeroDamage.NormalDamagePercentage = 0.5;
            HeroDamage.PoisonDamagePercentage = 0.5;
        }

        public override void SpecialPower()
        {
            int deadCharacters = battleGround.CountDeadCharacters();
            //If no one is dead and character is not poisoned, gain camouflage
            if (deadCharacters == 0 && CharacterStatus != CharacterStatus.Poisoned)
            {
                CharacterStatus = CharacterStatus.Hidden;
            }
            //Each time a fighter dies, the bony boi gains 5 attack/5 defense/50 life/50 max life TODO
        }

        public override int RollAttack()
        {
            //rolls are 1-150
            return Attack + DiceService.RollDice(1, 150);
        }

        public override int RollAttackSpeed()
        {
            //rolls are 1 - 150
            return (int) (Math.Ceiling(1000 / AttackSpeed) - DiceService.RollDice(1, 150));
        }

        public override int RollDefense()
        {
            //rolls are 1 - 150
            return Defense + DiceService.RollDice(1, 150);
        }
    }
}
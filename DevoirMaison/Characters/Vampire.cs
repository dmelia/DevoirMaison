using System;
using System.Threading;
using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    //Bloody boi
    public class Vampire : Character
    {
        private int DamageTakenCounter = 0;
        public Vampire(string name, BattleGround battleGround)
        {
            Name = name;
            Attack = 125;
            Defense = 125;
            AttackSpeed = 2;
            Damages = 50;
            MaximumLife = 150;
            CurrentLife = 150;
            PowerSpeed = 0.2;
            //Double damage from Sacred
            CharacterType = CharacterType.Undead;
            base.battleGround = battleGround;
            HeroDamage.NormalDamagePercentage = 1;
        }

        public override void SpecialPower()
        {
            //Selects a random target and increases its attack delay of an amount equal to damage that the bloody boi received since the last use of his power
            Character target = battleGround.FindFirstTarget(true, this);
            var targetAttackCooldown = target.AttackCooldown;
            Interlocked.Add(ref targetAttackCooldown, DamageTakenCounter);
            DamageTakenCounter = 0;
            Console.WriteLine("Bloody boi made {0} slow down !", target.Name);
        }
        
        public virtual void TakeDamage(int amount)
        {
            CurrentLife -= amount;
            if (CurrentLife <= 0)
            {
                IsDead = true;
            }

            //Increment damage counter by amount of damage taken
            DamageTakenCounter += amount;
        }

        public override void TargetCharacterAndAttack()
        {
            //Bloody boi heals himself for 50% of damage dealt to target
            throw new System.NotImplementedException();
        }
        //Double damage from Sacred
        
    }
}
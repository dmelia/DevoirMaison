using System;
using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    //Bitey boi
    public class Zombie : Character
    {
        public Zombie(string name, BattleGround battleGround)
        {
            Name = name;
            Defense = 0;
            AttackSpeed = 1;
            Damages = 20;
            MaximumLife = 1500;
            CurrentLife = 1500;
            Attack = 150;
            PowerSpeed = 0.1;
            //Double damage from Sacred
            CharacterType = CharacterType.Undead;
            base.battleGround = battleGround;
            HeroDamage.NormalDamagePercentage = 1;
            //Immune to poison
            IsImmuneToPoison = true;
        }

        public override void SpecialPower()
        {
            Character target = battleGround.FindEdibleCorpse();
            if (target != null)
            {
                Console.WriteLine("Bitey Boi eats a fresh cadaver");
                //consumes a random dead player, gain hp equal to the dead players max life
                GainLife(target.MaximumLife);
                target.IsCorpseConsumed = true;
            }
        }
        
        //Bitey boi does not receive attack delay when hit
        public override void AddAttackCooldown(int amount)
        {
            //Do nothing
        }

        public override int RollDefense()
        {
            //Defense roll always equal to 0
            return 0;
        }
    }
}
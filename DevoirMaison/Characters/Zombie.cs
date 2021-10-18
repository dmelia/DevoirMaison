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
            BaseDamageType = DamageType.Normal;
            CharacterType = CharacterType.Undead;
            base.battleGround = battleGround;
        }

        public override void SpecialPower()
        {
            Console.WriteLine("Bitey Boi eats a fresh cadaver");
            Character target = battleGround.FindEdibleCorpse();
            //consumes a random dead player, gain hp equal to the dead players max life
            GainLife(target.MaximumLife);
            CorpseEventArgs args = new CorpseEventArgs();
            args.Target = target;
            
        }

        
            //Immune to poison
            //Defense roll always equal to 0
            //Double damage from Sacred

            public override int RollAttack()
        {
            //Bitey boi's attack delay roll is always 0
            throw new System.NotImplementedException();
        }

        public override int RollSpeed()
        {
            throw new System.NotImplementedException();
        }
    }
}
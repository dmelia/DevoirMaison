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
            target.IsCorpseConsumed = true;
        }

        public override void TargetCharacterAndAttack()
        {
            throw new NotImplementedException();
        }

        //Immune to poison
        //Defense roll always equal to 0
        //Double damage from Sacred
        //Bitey boi's attack delay roll when hit is always 0
    }
}
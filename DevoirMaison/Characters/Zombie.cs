using System;

namespace DevoirMaison
{
    //Bitey boi
    public class Zombie: Character
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
            DamageType = DamageType.Normal;
            CharacterType = CharacterType.Undead;
            base.battleGround = battleGround;
        }

        public override void SpecialPower()
        {
            Console.WriteLine("Bitey Boi eats a fresh cadaver");
            //consumes a random dead player, gain hp equal to the dead players max life
            throw new System.NotImplementedException();
        }

        public override bool ReceiveDamage(Damage damage)
        {
            //Immune to poison
            //Defense roll always equal to 0
            //Double damage from Sacred
            return true;
        }

        public override int RollAttack()
        {
            //Bitey boi's attack delay roll is always 0
            throw new System.NotImplementedException();
        }

        public override int RollSpeed()
        {
            throw new System.NotImplementedException();
        }

        public override Character TargetCharacterAndAttack()
        {
            throw new NotImplementedException();
        }
    }
}
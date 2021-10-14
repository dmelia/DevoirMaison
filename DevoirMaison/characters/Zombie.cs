using System;

namespace DevoirMaison
{
    //Bitey boi
    public class Zombie: Character
    {
        public Zombie(string name)
        { 
            Name = name;
            Defense = 0;
            AttackSpeed = 1;
            Damages = 20;
            MaximumLife = 1500;
            CurrentLife = 1500;
            Attack = 150;
            PowerSpeed = 0.1;
            _DamageType = DamageType.Normal;
            _CharacterType = CharacterType.Undead;
        }

        public override void SpecialPower(BattleGround battleGround)
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
            throw new System.NotImplementedException();
        }

        public override float RollSpeed()
        {
            throw new System.NotImplementedException();
        }

        public override int RollAttackDelay()
        {
            //Bitey boi's attack delay roll is always 0
            return 0;
        }

        public override Character TargetCharacterAndAttack(BattleGround battleGround)
        {
            throw new NotImplementedException();
        }
    }
}
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
            CharacterType = CharacterType.Undead;
            base.battleGround = battleGround;
            HeroDamage.NormalDamagePercentage = 1;
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

        
        //Defense roll always equal to 0
        //Double damage from Sacred
        //Immune to poison
        //Bitey boi's attack delay roll when hit is always 0
        public override void TakeAttackDamage(int amount, HeroDamage heroDamage)
        {
            int damageTaken = (int) Math.Ceiling((double) ((amount) * (Damages / 100)));
            TakeDamage(damageTaken);
        }
    }
}
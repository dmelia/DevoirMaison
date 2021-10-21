using System.Threading;
using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    //Pally boi
    public class Paladin : Character
    {
        public Paladin(string name, BattleGround battleGround)
        {
            Name = name;
            Attack = 60;
            Defense = 145;
            AttackSpeed = 1.6;
            Damages = 40;
            MaximumLife = 250;
            CurrentLife = 250;
            PowerSpeed = 0.5;
            CharacterType = CharacterType.Human;
            base.battleGround = battleGround;
            //Deals sacred damage
            HeroDamage.SacredDamagePercentage = 1;
        }

        public override void SpecialPower()
        {
            //Reduces delay to 0 of next hit
            var attackCooldown = AttackCooldown;
            Interlocked.Add(ref attackCooldown, -AttackCooldown);
        }
    }
}
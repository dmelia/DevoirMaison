using System;
using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    //Clony boi
    public class Illusionist : Character
    {
        private readonly int BaseAttack = 75;
        public Illusionist(string name, BattleGround battleGround)
        {
            Name = name;
            Defense = 75;
            AttackSpeed = 1;
            Damages = 50;
            MaximumLife = 100;
            CurrentLife = 100;
            Attack = BaseAttack;
            PowerSpeed = 0.5;
            CharacterType = CharacterType.Human;
            base.battleGround = battleGround;
            HeroDamage.NormalDamagePercentage = 1;
        }

        public override void SpecialPower()
        {
            //Creates a double of himself
            //Doubles can cumulate
            if (!IsClone && !IsDead)
            {
                Illusionist _double = new Illusionist("Double", battleGround);
                _double.IsClone = true;
                battleGround.Characters.Add(_double);
                _double.StartLife();
                Console.WriteLine("Clony boi cloned himself !");
            }
        }

        public override int RollAttack()
        {
            //For each double in combat (that's alive), gain 10 Attack
            int doublesCount = battleGround.CountDoubles();
            if (!IsClone) //Doubles don't get the bonus damage (that would be stupid)
            {
                Attack = BaseAttack + (doublesCount * 10);
            }

            return base.RollAttack();
        }
    }
}
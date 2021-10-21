using System;
using System.Timers;
using DevoirMaison.Combat;

namespace DevoirMaison.Characters
{
    //Hitty boi
    public class Warrior : Character
    {
        private const double BaseAttackSpeed = 2.2;
        private DateTime _buffDateTime;
        private Timer _timer = new Timer();

        public Warrior(string name, BattleGround battleGround)
        {
            Name = name;
            Defense = 105;
            AttackSpeed = BaseAttackSpeed;
            Damages = 150;
            MaximumLife = 250;
            CurrentLife = 250;
            Attack = 150;
            PowerSpeed = 0.2;
            CharacterType = CharacterType.Human;
            base.battleGround = battleGround;
            HeroDamage.NormalDamagePercentage = 1;
        }

        public override void SpecialPower()
        {
            Console.WriteLine("We purposely trained {0} wrong, as a joke !", Name);
            AttackSpeed = BaseAttackSpeed + 0.5;
            _buffDateTime = DateTime.Now;
        }

        public override void StartLife()
        {
            _timer = new Timer();
            _timer.Elapsed += (_, _) =>
            {
                if (IsDead) _timer.Stop();
            };
            _timer.Elapsed += RemoveBuffTimer;
            base.StartLife();
            _timer.Enabled = true;
        }

        private void RemoveBuffTimer(object source, ElapsedEventArgs args)
        {
            if (TimeDifferenceFromNow(_buffDateTime) > 3000)
            {
                AttackSpeed = BaseAttackSpeed;
            }
        }
    }
}
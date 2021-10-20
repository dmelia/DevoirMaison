using System;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using DevoirMaison.Combat;
using Timer = System.Timers.Timer;

namespace DevoirMaison.Characters
{
    public abstract class Character
    {
        private static int _poisonCooldown = 5000;
        public BattleGround battleGround { get; set; }
        public string Name { get; set; }

        public DamageType BaseDamageType { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        public double AttackSpeed { get; set; }

        public int Damages { get; set; }

        public int MaximumLife { get; set; }

        public int CurrentLife { get; set; }

        public double PowerSpeed { get; set; }

        public DateTime LastAttackDate { get; set; }

        public DateTime LastPowerDate { get; set; }

        public int AttackCooldown { get; set; }

        public DateTime LastPoisonHitDate { get; set; }

        public int PoisonCounter { get; set; }

        public CharacterType CharacterType { get; set; }

        public bool IsDead { get; set; } = false;

        public bool IsCorpseConsumed { get; set; } = false;

        public bool IsDouble { get; set; } = false;

        public CharacterStatus CharacterStatus { get; set; } = CharacterStatus.Normal;

        public abstract void SpecialPower();

        public abstract void TargetCharacterAndAttack();

        public virtual int RollAttack()
        {
            return Attack + DiceService.RollDice(1, 100);
        }

        public virtual int RollDefense()
        {
            return Defense + DiceService.RollDice(1, 100);
        }

        public virtual int RollAttackSpeed()
        {
            return (int) (Math.Ceiling(1000 / AttackSpeed) - DiceService.RollDice(1, 100));
        }

        public virtual int GetPowerDelay()
        {
            return (int) Math.Ceiling(1000 / PowerSpeed);
        }

        public void GainLife(int amount)
        {
            CurrentLife += amount;
            if (CurrentLife > MaximumLife)
            {
                CurrentLife = MaximumLife;
            }
        }

        public void TakeDamage(int amount)
        {
            CurrentLife -= amount;
            if (CurrentLife <= 0)
            {
                IsDead = true;
            }
        }

        public void TakeAttackDamage(int amount)
        {
            int defenseRoll = RollDefense();
            if (defenseRoll < amount)
            {
                var attackCooldown = AttackCooldown;
                Interlocked.Add(ref attackCooldown, amount);
                int damageTaken = (int) Math.Ceiling((double) ((amount - defenseRoll) * (Damages / 100)));
                TakeDamage(damageTaken);
            }
        }


        private Timer _timer;

        public void StartLife()
        {
            Console.WriteLine("{0} is joining the fight ! The character is a {1} {2}", Name, CharacterType,
                this.GetType().Name);
            _timer = new Timer();
            _timer.AutoReset = false;
            _timer.Elapsed += (_, _) =>
            {
                if (IsDead) _timer.Stop();
            };
            _timer.Elapsed += AttackElapsedHandler;
            _timer.Elapsed += PowerElapsedHandler;
            _timer.Elapsed += PoisonedElapsedHandler;
        }

        public async void AttackElapsedHandler(object source, ElapsedEventArgs args)
        {
            await Task.Run(() =>
            {
                Task.Delay(AttackCooldown);
                //Attack
                TargetCharacterAndAttack();

                //Roll attack delay
                AttackCooldown = RollAttackSpeed();
            });
        }

        public async void PowerElapsedHandler(object source, ElapsedEventArgs args)
        {
            //Use power
            await Task.Run(() =>
            {
                Task.Delay(GetPowerDelay());
                SpecialPower();
            });
        }

        public async void PoisonedElapsedHandler(object source, ElapsedEventArgs args)
        {
            //Take Poison Damage if poisoned
            await Task.Run(() =>
            {
                if (CharacterStatus == CharacterStatus.Poisoned)
                {
                    Task.Delay(_poisonCooldown);
                    TakeDamage(PoisonCounter);
                }
            });
        }

        public static int TimeDifferenceFromNow(DateTime start)
        {
            DateTime now = DateTime.Now;
            TimeSpan span = now - start;
            return (int) span.TotalMilliseconds;
        }
    }
}
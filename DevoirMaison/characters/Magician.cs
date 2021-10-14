namespace DevoirMaison
{
    //Firery boi
    public class Magician : Character
    {
        public Magician(string name)
        {
            Name = name;
            Attack = 75;
            Defense = 125;
            AttackSpeed = 1.5;
            Damages = 100;
            MaximumLife = 125;
            CurrentLife = 125;
            PowerSpeed = 0.1;
            _DamageType = DamageType.Normal;
            _CharacterType = CharacterType.Human;
        }

        public override void SpecialPower(BattleGround battleGround)
        {
            //Special is an attack
            //Targets multiple enemies
            //When it hits 1st enemy, damage is reduced by 10% (from total initial damage)
            //After hit, targets another enemy
            //continues hitting enemies and reducing damage by 10% until damage is 0 or that a player was able to defend.
            //If 1st target was able to defend, it does not chain
            //Initial damage is attack damage multiplied by 5
            throw new System.NotImplementedException();
        }

        public override bool ReceiveDamage(Damage damage)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public override Character TargetCharacterAndAttack(BattleGround battleGround)
        {
            throw new System.NotImplementedException();
        }
    }
}
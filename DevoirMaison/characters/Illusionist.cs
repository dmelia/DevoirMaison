namespace DevoirMaison
{
    //Clony boi
    public class Illusionist : Character
    {
        public Illusionist(string name)
        {
            Name = name;
            Defense = 75;
            AttackSpeed = 1;
            Damages = 50;
            MaximumLife = 100;
            CurrentLife = 100;
            Attack = 75;
            PowerSpeed = 0.5;
            _DamageType = DamageType.Normal;
            _CharacterType = CharacterType.Human;
        }

        private Illusionist CreateDouble()
        {
            Illusionist _double = new Illusionist("Double");
            _double.IsDouble = true;
            return _double;
        }

        public override void SpecialPower(BattleGround battleGround)
        {
            //Creates a double of himself
            //Doubles can cumulate
            //If hit and takes damage, double is destroyed
            //Effectively, making a double with 1 current HP is enough
            throw new System.NotImplementedException();
        }

        public override bool ReceiveDamage(Damage damage)
        {
            if (IsDouble)
            {
                //
            }
            throw new System.NotImplementedException();
        }

        public override int RollAttack()
        {
            //For each double in combat (that's alive), gain 10 Attack
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
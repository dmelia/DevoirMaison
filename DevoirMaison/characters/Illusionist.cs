namespace DevoirMaison
{
    //Clony boi
    public class Illusionist : Character
    {
        public Illusionist(string name, BattleGround battleGround)
        {
            Name = name;
            Defense = 75;
            AttackSpeed = 1;
            Damages = 50;
            MaximumLife = 100;
            CurrentLife = 100;
            Attack = 75;
            PowerSpeed = 0.5;
            DamageType = DamageType.Normal;
            CharacterType = CharacterType.Human;
            base.battleGround = battleGround;
        }

        private Illusionist CreateDouble()
        {
            Illusionist _double = new Illusionist("Double", battleGround);
            _double.IsDouble = true;
            return _double;
        }

        public override void SpecialPower()
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

        public override int RollSpeed()
        {
            throw new System.NotImplementedException();
        }

        public override Character TargetCharacterAndAttack()
        {
            throw new System.NotImplementedException();
        }
    }
}
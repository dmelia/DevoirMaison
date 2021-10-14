namespace DevoirMaison
{
    //Potion-y boi
    public class Alchemist: Character
    {
        public Alchemist(string name)
        {
            Name = name;
            Attack = 50;
            Defense = 50;
            AttackSpeed = 1;
            Damages = 30;
            MaximumLife = 150;
            CurrentLife = 150;
            PowerSpeed = 0.1;
            _DamageType = DamageType.Sacred;
            _CharacterType = CharacterType.Human;
        }

        public override void SpecialPower(BattleGround battleGround)
        {
            //Exchange current life value with highest current life value of any hero in combat
            //After trade, new values of current life cannot exceed maximum life
            throw new System.NotImplementedException();
        }

        public override bool ReceiveDamage(Damage damage)
        {
            throw new System.NotImplementedException();
        }

        public override int RollAttack()
        {
            //rolls are 1 - 200
            throw new System.NotImplementedException();
        }

        public override float RollSpeed()
        {
            //rolls are 1 - 200
            throw new System.NotImplementedException();
        }

        public override int RollAttackDelay()
        {
            //rolls are 1 - 200
            throw new System.NotImplementedException();
        }

        public override Character TargetCharacterAndAttack(BattleGround battleGround)
        {
            //All characters have 50% chance to be targeted by the Alchemist's attack
            //All characters are considered as secondary targets (can hit even hidden characters)
            //100% of damage dealt as poison and 50% of damage dealt as normal
            throw new System.NotImplementedException();
        }
    }
}
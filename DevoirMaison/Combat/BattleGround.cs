using System.Collections.Generic;

namespace DevoirMaison
{
    public class BattleGround
    {
        public List<Character> Characters
        {
            get;
            set;
        }

        public BattleGround()
        {
            this.Characters = new List<Character>();
        }
    }
}
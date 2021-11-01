using System;

namespace DevoirMaison
{
    
    public class DiceService
    {
        private static Random _random = new (DateTime.Now.Millisecond);

        public static int RollDice(int start, int end)
        {
            int roll = _random.Next(start, end + 1);
            return roll;
        }
    }
}
using System;

namespace DevoirMaison
{
    
    public class DiceService
    {
        private static Random _random = new Random((int) DateTime.Now.Millisecond);

        public static int RollDice(int start, int end)
        {
            return _random.Next(start, end);
        }
    }
}
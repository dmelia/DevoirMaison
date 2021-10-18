using System;
using DevoirMaison.Combat;

namespace DevoirMaison
{
    class Program
    {
        static void Main(string[] args)
        {
            BattleGround battleGround = new BattleGround();
            battleGround.PopulateBattleGround();
            battleGround.StartBattle();

            while (battleGround.ArePlayersAlive())
            {
                //Battle working here
            }

            Console.WriteLine("Battle ended");
            Console.Read();
        }
    }
}
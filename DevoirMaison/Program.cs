using System;
using DevoirMaison.Characters;
using DevoirMaison.Combat;
using DevoirMaison.Statistics;

namespace DevoirMaison
{
    class Program
    {
        static void Main(string[] args)
        {
            for(int i = 0; i< 50; i++) {
            BattleGround battleGround = new BattleGround();
            battleGround.PopulateBattleGround();
            battleGround.StartBattle();

            while (battleGround.ArePlayersFighting())
            {
                //Battle working here
            }

            Console.WriteLine("Battle ended");
            Character winner = battleGround.Characters.Find(character => !character.IsDead);
            Console.WriteLine("Winner was : {0}", winner?.Name);
            StatisticsService.SaveCharacterWon(winner);
            StatisticsService.ShowCharacterWins();
            }
            Console.Read();
        }
    }
}
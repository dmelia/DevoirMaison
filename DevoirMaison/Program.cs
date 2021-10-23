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

            while (battleGround.ArePlayersFighting())
            {
                //Battle working here
            }

            Console.WriteLine("Battle ended");
            Console.WriteLine("Winner was : {0}", battleGround.Characters.Find(character => !character.IsDead)?.Name);
            Console.Read();
        }
    }
}
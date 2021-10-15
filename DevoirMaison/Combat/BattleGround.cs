using System;
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

        public void PopulateBattleGround()
        {
            Characters.Add(new Alchemist("Potiony-boi", this));
            Characters.Add(new Assassin("Dodgy-boi", this));
            Characters.Add(new Berserker("Slappy-boi", this));
            Characters.Add(new Illusionist("Clony-boi", this));
            Characters.Add(new Magician("Brainy-boi", this));
            Characters.Add(new Necromancer("Bony-boi", this));
            Characters.Add(new Paladin("Pally-boi", this));
            Characters.Add(new Priest("Lighty-boi", this));
            Characters.Add(new Robot("Shiny-Boi", this));
            Characters.Add(new Vampire("Bloody-boi", this));
            Characters.Add(new Warrior("Hitty-boi", this));
            Characters.Add(new Zombie("Bitey-boi", this));
        }

        public void StartBattle()
        {
            foreach (var character in Characters)
            {
                Console.WriteLine("Oh it's on now!");
                character.StartLife();
            }
        }
    }
}
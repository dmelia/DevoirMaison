﻿using System;
using System.Collections.Generic;
using System.Linq;
using DevoirMaison.Characters;

namespace DevoirMaison.Combat
{
    public class BattleGround
    {
        //If set to false, battle has not started and players cannot use skills or attacks
        public bool BattleStarted { get; set; } = false;
        public List<Character> Characters
        {
            get;
            set;
        }

        public BattleGround()
        {
            this.Characters = new List<Character>();
        }

        //Populates the battle ground with characters
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
            Console.WriteLine("Characters are joining the battle!");
            foreach (var character in Characters)
            {
                character.StartLife();
            }

            Console.WriteLine("Battle starting!");
            BattleStarted = true;
        }

        public bool ArePlayersAlive()
        {
            return Characters.Any(character => character.IsDead);
        }

        //Returns a random consumable corpse
        public Character FindEdibleCorpse()
        {
            var random = new Random(DateTime.Now.Millisecond);
            List<Character> deadCharacters = Characters.FindAll(character => character.IsDead);
            int count = deadCharacters.Count;
            int rand = random.Next(count);
            return deadCharacters[rand];
        }

        public List<Character> FindTargetableCharacters()
        {
            return Characters.FindAll(character => !character.IsDead);
        }
    }
}
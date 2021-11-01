using System;
using System.Collections.Generic;
using System.Linq;
using DevoirMaison.Characters;

namespace DevoirMaison.Combat
{
    public class BattleGround
    {
        //If set to false, battle has not started and players cannot use skills or attacks
        public bool BattleStarted { get; set; } = false;
        public List<Character> Characters { get; set; }

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

            List<Necromancer> necromancers = new List<Necromancer>();
            foreach (var character in Characters)
            {
                if(character.GetType() == typeof(Necromancer))
                {
                    necromancers.Add(character as Necromancer);
                }
            }

            foreach (var necromancer in necromancers)
            {
                foreach (var character in Characters)
                {
                    if (character != necromancer)
                    {
                        character.Death += necromancer.GetBuffed;
                    }
                }
            }
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

        public bool AreAllPlayersAlive()
        {
            bool result = Characters.Any(character => character.IsDead);
            return result;
        }
        
        public bool ArePlayersFighting()
        {
            bool result = Characters.Count(character => !character.IsDead) > 1;
            return result;
        }

        //Returns a random consumable corpse
        public Character FindEdibleCorpse()
        {
            var random = new Random(DateTime.Now.Millisecond);
            List<Character> deadCharacters = Characters.FindAll(character => character.IsDead && !character.IsCorpseConsumed);
            int count = deadCharacters.Count;
            int rand = random.Next(count);
            return deadCharacters[rand];
        }

        //Returns the current character with the highest life value on the battle field
        public Character FindHighestHealthCharacter()
        {
            Character result = Characters.OrderByDescending(character => character.CurrentLife)
                .First(character => !character.IsDead);
            return result;
        }

        //Finds all living characters except the character that invoked the call
        public List<Character> FindLivingCharacters(Character self)
        {
            List<Character> result = Characters.FindAll(character => !character.IsDead && character != self);
            return result;
        }

        //Returns a random character that can be targeted, except self
        public Character FindTarget(bool canTargetHidden, Character self, bool prioritiseUndead)
        {
            if (Characters.Count(character => !character.IsDead) <= 5)
            {
                //Hidden does nothing if there are less than 5 characters alive
                canTargetHidden = true;
            }
            
            List<Character> potentialTargets;
            if (!canTargetHidden)
            {
                potentialTargets = Characters.FindAll(character =>
                    !character.IsDead && character.CharacterStatus != CharacterStatus.Hidden && character != self);
            }
            else
            {
                potentialTargets = Characters.FindAll(character => !character.IsDead && character != self);
            }
            if (prioritiseUndead)
            {
                potentialTargets = potentialTargets.FindAll(character => character.CharacterType == CharacterType.Undead);
            }
            var random = new Random(DateTime.Now.Millisecond);
            int count = potentialTargets.Count;
            int rand = random.Next(count);
            return potentialTargets[rand];
        }

        public int CountDoubles()
        {
            return Characters.FindAll(character => character.IsClone && !character.IsDead).Count;
        }
    }
}
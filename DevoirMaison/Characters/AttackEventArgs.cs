using System;

namespace DevoirMaison.Characters
{
    public class AttackEventArgs : EventArgs
    {
        public Damage DamageTaken { get; set; }
        public Character Target { get; set; }
    }
}
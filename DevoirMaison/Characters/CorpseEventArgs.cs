using System;

namespace DevoirMaison.Characters
{
    public class CorpseEventArgs : EventArgs
    {
        public Character Target { get; set; }
    }
}
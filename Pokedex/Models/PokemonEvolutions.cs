using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Models
{
    public class Chain
    {
        public List<EvolvesTo> evolves_to { get; set; }
        public Species species { get; set; }
    }

    public class EvolvesTo
    {
        public List<EvolvesTo> evolves_to { get; set; }
        public Species species { get; set; }
    }

    public class Item
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class PokemonEvolutions
    {
        public Chain chain { get; set; }
    }

    public class Species
    {
        public string name { get; set; }
        public string url { get; set; }
    }
}

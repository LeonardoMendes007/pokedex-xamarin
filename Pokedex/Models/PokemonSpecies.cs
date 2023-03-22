using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex.Models
{
    public class PokemonSpecies
    {
        [JsonProperty("evolution_chain")]
        public EvolutionChain EvolutionChain { get; set; }
        [JsonProperty("flavor_text_entries")]
        public List<FlavorTextEntry> FlavorTextEntries { get; set; }
    }

    public class EvolutionChain
    {
        public string Url { get; set; }
    }

    public class FlavorTextEntry
    {
        [JsonProperty("flavor_text")]
        public string FlavorText { get; set; }
        public Language Language { get; set; }
    }

    public class Language
    {
        public string Name { get; set; }
    }
}

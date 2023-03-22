using Newtonsoft.Json;
using Pokedex.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Essentials;
using static System.Net.Mime.MediaTypeNames;

namespace Pokedex.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [JsonProperty("base_experience")]
        public int BaseExperience { get; set; }
        public int Height { get; set; }
        [JsonProperty("is_default")]
        public bool IsDefault { get; set; }
        public int Order { get; set; }
        public int Weight { get; set; }
        [JsonProperty("location_area_encounters")]
        public string LocationAreaEncounters { get; set; }
        public List<Types> Types { get; set; }
        public Sprites Sprites { get; set; }
        public List<Abilities> Abilities { get; set; }
        public List<Pokemon> Evolutions { get; set; }
        public PokemonSpecies Specie { get; set; }
        
        public string GetHeightFormated
        {
            get
            {
                return Height + " inches";
            }
        }

        public string GetWeightFormated
        {
            get
            {
                return Weight + "g";
            }
        }

        public string GetDescriptionWithAudio
        {
            get{
                var description = Specie.FlavorTextEntries.Where(x => x.Language.Name.Equals("en")).Select(x => x.FlavorText).Random().Replace("\n", " ").ToLower();
                TextToSpeech.SpeakAsync(Name);
                TextToSpeech.SpeakAsync(description);
                return description;
            }
        }

        public string GetDescription
        {
            get
            {
                return Specie.FlavorTextEntries.Where(x => x.Language.Name.Equals("en")).Select(x => x.FlavorText).Random().Replace("\n", " ").ToLower();
            }
        }
    }

    public class Abilities
    {
        public Ability Ability { get; set; }
    }

    public class Ability
    {
        public string Name { get; set; }
    }

    public class Sprites
    {
        public Other Other { get; set; }
    }

    public class Other
    {
        [JsonProperty("official-artwork")]
        public OfficialArtwork OfficialArtwork { get; set; }
    }

    public class OfficialArtwork
    {
        [JsonProperty("front_default")]
        public string FrontDefault { get; set; }
    }

    public class Types
    {
        public Type Type { get; set; }
    }

    public class Type
    {
        public string Name { get; set; }
    }
}

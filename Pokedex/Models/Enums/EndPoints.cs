using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Pokedex.Models.Enums
{
    public enum EndPoints
    {
        [Description("")]
        Prediction,
        [Description("api/v2/pokemon/")]
        Pokemon,
        [Description("api/v2/pokemon-species/")]
        PokemonSpecies
    }
}

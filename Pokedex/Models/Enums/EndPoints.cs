using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Pokedex.Models.Enums
{
    public enum EndPoints
    {
        [Description("customvision/v3.0/Prediction/eaf004ce-894a-47d9-b346-e323981ac48f/classify/iterations/Iteration1/image")]
        Prediction,
        [Description("api/v2/pokemon/")]
        Pokemon,
        [Description("api/v2/pokemon-species/")]
        PokemonSpecies
    }
}

using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Services.Interfaces
{
    public interface IPokemonService
    {
        Task<Pokemon> ObterPokemonByNameAsync(string name);
        Task<PokemonSpecies> ObterPokemonSpeciesByNameAsync(string name);
        Task<List<Pokemon>> ObterEvolutionChainAsync(string url);

    }
}

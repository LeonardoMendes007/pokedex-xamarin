using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Facade.Interfaces
{
    public interface IPokemonFacade
    {
        Task<Pokemon> ObterDadosPokemonByNameAsync(string name);
        Task<PokemonSpecies> ObterDadosPokemonSpecieByNameAsync(string name);
        Task<List<Pokemon>> ObterDadosPokemonEvolutionsAsync(string url);
    }
}

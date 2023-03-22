using Newtonsoft.Json;
using Pokedex.Models.Enums;
using Pokedex.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Pokedex.Services.Interfaces;
using Pokedex.Facade.Interfaces;
using System.Linq;

namespace Pokedex.Facade
{
    public class PokemonFacade : IPokemonFacade
    {
        private readonly IPokemonService _pokemonService;

        public PokemonFacade(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public async Task<Pokemon> ObterDadosPokemonByNameAsync(string name)
        {
            var pokemon = await _pokemonService.ObterPokemonByNameAsync(name);

            if (pokemon == null)
                return null;

            var pokemonSpecie = await ObterDadosPokemonSpecieByNameAsync(name);

            if (pokemonSpecie == null)
                return null;

            pokemon.Specie = pokemonSpecie;

            pokemon.Evolutions = await ObterDadosPokemonEvolutionsAsync(pokemon.Specie.EvolutionChain.Url);

            return pokemon;
        }

        public async Task<List<Pokemon>> ObterDadosPokemonEvolutionsAsync(string url)
        {
            var listPokemons = await _pokemonService.ObterEvolutionChainAsync(url);

            if (listPokemons == null)
                return null;

            foreach (var item in listPokemons)
            {
                var pokemonSpecie = await ObterDadosPokemonSpecieByNameAsync(item.Name);

                if (pokemonSpecie == null)
                    return null;

                item.Specie = pokemonSpecie;
            }

            return listPokemons;
        }

        public async Task<PokemonSpecies> ObterDadosPokemonSpecieByNameAsync(string name)
        {
            return await _pokemonService.ObterPokemonSpeciesByNameAsync(name);
        }
    }
}

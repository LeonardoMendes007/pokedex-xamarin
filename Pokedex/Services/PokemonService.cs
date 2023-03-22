using Newtonsoft.Json;
using Pokedex.Extensions;
using Pokedex.Models;
using Pokedex.Models.Enums;
using Pokedex.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Pokemon> ObterPokemonByNameAsync(string name)
        {
            try
            {
                var response = await _httpClient.GetAsync(EndPoints.Pokemon.GetDescription() + name.ToLower());

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<Pokemon>(await response.Content.ReadAsStringAsync());
                }

                return null;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Não foi possivel obter dados do pokemon" + ex);
                return null;
            }
           
        }

        public async Task<PokemonSpecies> ObterPokemonSpeciesByNameAsync(string name)
        {
            try
            {
                var response = await _httpClient.GetAsync(EndPoints.PokemonSpecies.GetDescription() + name.ToLower());

                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<PokemonSpecies>(await response.Content.ReadAsStringAsync());
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel obter dados do pokemon species" + ex);
                return null;
            }

        }

        public async Task<List<Pokemon>> ObterEvolutionChainAsync(string url)
        {
            try
            { 
                var response = await _httpClient.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    List<Pokemon> evolutions = new List<Pokemon>();
                    
                    var body = JsonConvert.DeserializeObject<PokemonEvolutions>(await response.Content.ReadAsStringAsync());
                    evolutions.Add(await ObterPokemonByNameAsync(body.chain.species.name));
                    var evolves = body.chain.evolves_to;

                    while ( evolves.Count > 0)
                    {
                        evolutions.Add(await ObterPokemonByNameAsync(evolves[0].species.name));
                        evolves = evolves[0].evolves_to;
                    }

                    return evolutions;
                }

                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possivel obter dados do pokemon species" + ex);
                return null;
            }

        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Pokedex.Services.Interfaces;
using Pokedex.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Pokedex.Facade;
using Pokedex.Facade.Interfaces;
using Pokedex.Infra.Data;

namespace Pokedex.Config
{
    public static class ConfigureServices
    {
        public static IServiceCollection ConfigureDependencyInjection(this IServiceCollection services)
        {
            #region Services

            services.AddScoped<IPredictService, CustomVisionService>();
            services.AddScoped<IPokemonService, PokemonService>();
            services.AddScoped<IPokemonFacade, PokemonFacade>();
            services.AddSingleton<ApplicationContext>();

            #endregion

            #region HttpClient

            services.AddHttpClient<IPredictService, CustomVisionService>(x =>
            {
                //Endereço da api de predição do custom vision.
                x.BaseAddress = new Uri("");
            });

            services.AddHttpClient<IPokemonService, PokemonService>(x =>
            {
                x.BaseAddress = new Uri("https://pokeapi.co/");
            });

            #endregion

            return services;
        }
    }
}

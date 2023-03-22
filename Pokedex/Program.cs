using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Pokedex.Config;
using Pokedex.Services;
using Pokedex.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pokedex
{
    public static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static IServiceProvider init()
        {
            var serviceProvider = new ServiceCollection()
                .ConfigureDependencyInjection()
                .BuildServiceProvider();
            ServiceProvider = serviceProvider;

            return serviceProvider;
        }
    }
}

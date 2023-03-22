using Pokedex.ViewModels;
using Pokedex.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Pokedex
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(PokemonDetailPage), typeof(PokemonDetailPage));
        }

    }
}

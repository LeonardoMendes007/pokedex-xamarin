using Pokedex.Models;
using Pokedex.ViewModels;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Pokedex.Views
{
    public partial class PokemonDetailPage : ContentPage
    {
        PokemonDetailViewModel _viewModel;
        public PokemonDetailPage(Pokemon pokemon)
        {
            InitializeComponent();
            this.BindingContext = new PokemonDetailViewModel(pokemon);
        }

        public PokemonDetailPage() {
            InitializeComponent();
        }
    }
}
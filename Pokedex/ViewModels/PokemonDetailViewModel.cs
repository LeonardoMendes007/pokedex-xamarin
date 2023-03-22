using Newtonsoft.Json;
using Pokedex.Models;
using Pokedex.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pokedex.ViewModels
{
    public class PokemonDetailViewModel : BaseViewModel
    {
        private Pokemon _selectedItem;
        public Pokemon Pokemon { get; set; }
        public Command<Pokemon> PokemonTapped { get; }

        public PokemonDetailViewModel(Pokemon pokemons)
        {
            this.Pokemon = pokemons;
            PokemonTapped = new Command<Pokemon>(OnPokemonSelected);
        }

        public Pokemon SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnPokemonSelected(value);
            }
        }
        async void OnPokemonSelected(Pokemon item)
        {
            if (item == null)
                return;

            item.Evolutions = Pokemon.Evolutions;

            await Shell.Current.Navigation.PopAsync();
            await Shell.Current.Navigation.PushAsync(new PokemonDetailPage(item));
        }
    }
}

using Microsoft.Extensions.DependencyInjection;
using Pokedex.Facade.Interfaces;
using Pokedex.Infra.Data;
using Pokedex.Infra.DTO;
using Pokedex.Models;
using Pokedex.Services.Interfaces;
using Pokedex.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Pokedex.ViewModels
{
    public class MeusPokemonsViewModel : BaseViewModel
    {
        private Pokemon _selectedPokemon;
        public ObservableCollection<Pokemon> Pokemons { get; }
        public Command LoadPokemonsCommand { get; }
        public Command<Pokemon> PokemonTapped { get; }

        private readonly IPokemonFacade _pokemonFacade;
        private readonly ApplicationContext _context;
        public MeusPokemonsViewModel()
        {
            Title = "Meus Pokemons";
            Pokemons = new ObservableCollection<Pokemon>();
            _pokemonFacade = Program.ServiceProvider.GetService<IPokemonFacade>();
            _context = Program.ServiceProvider.GetService<ApplicationContext>();
            LoadPokemonsCommand = new Command(async () => await ExecuteLoadPokemonsCommand());
            PokemonTapped = new Command<Pokemon>(OnPokemonSelected);
        }

        async Task ExecuteLoadPokemonsCommand()
        {
            IsBusy = true;

            try
            {
                Pokemons.Clear();
                var names = _context.conexao.Query<PokemonDTO>("Select Name from PokemonDTO").Select(x => x.Name).ToList();
                foreach(string x in names)
                {
                    Pokemons.Add(await _pokemonFacade.ObterDadosPokemonByNameAsync(x));
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedPokemon = null;
        }

        public Pokemon SelectedPokemon
        {
            get => _selectedPokemon;
            set
            {
                SetProperty(ref _selectedPokemon, value);
                OnPokemonSelected(value);
            }
        }

        async void OnPokemonSelected(Pokemon item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.Navigation.PushAsync(new PokemonDetailPage(item));
        }
    }
}
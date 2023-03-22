using Microsoft.Extensions.DependencyInjection;
using Pokedex.Facade.Interfaces;
using Pokedex.Infra.Data;
using Pokedex.Infra.DTO;
using Pokedex.Models;
using Pokedex.Services;
using Pokedex.Services.Interfaces;
using Pokedex.ViewModels;
using Pokedex.Views.LoadingView;
using System;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Pokedex.Views
{
    public partial class ScannerPage : ContentPage
    {
        private readonly IPredictService _customVisionService;
        private readonly IPokemonFacade _pokemonFacade;
        private readonly ApplicationContext _context;
        private string PhotoPath { get; set; }

        public ScannerPage()
        {
            _customVisionService = Program.ServiceProvider.GetService<IPredictService>();
            _pokemonFacade = Program.ServiceProvider.GetService<IPokemonFacade>();
            _context = Program.ServiceProvider.GetService<ApplicationContext>();
            InitializeComponent();
        }

        private async void btScanner_Clicked(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync();
                LoadPhotoAsync(photo);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {PhotoPath}");
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                DisplayAlert("Erro", "Não foi possivel abrir a camera.", "cancelar");
            }
            catch (PermissionException pEx)
            {
                DisplayAlert("Erro", "Não foi dada a permissão necessária para acessar a camera", "cancelar");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
            }
        }

        private async Task LoadPhotoAsync(FileResult photo)
        {
            try
            {
                await ExibirLoading();
                if (photo == null)
                {
                    PhotoPath = null;
                    return;
                }

                var nomePokemon = await _customVisionService.IdentificarPokemon(photo.FullPath);

                if (nomePokemon != null){
                    var pokemon = await _pokemonFacade.ObterDadosPokemonByNameAsync(nomePokemon);
                    
                    if(pokemon != null) {
                        await RemoverLoading();
                        await Navigation.PushAsync(new PokemonDetailPage(pokemon));
                        InserirPokemon(pokemon.Name);
                        return;
                    }

                    await RemoverLoading();
                    DisplayAlert("Erro", "Não foi possivel identificar o pokemon.", "Cancelar");
                    return;
                }
                
                await RemoverLoading();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private void InserirPokemon(string name)
        {
            var algo = _context.conexao.Query<PokemonDTO>("Select * from PokemonDTO where Name = @Param", name);

            if (algo.Count == 0)
                _context.Insert(new PokemonDTO() { Name = name });
        }

        private async Task ExibirLoading()
        {
            await Navigation.PushModalAsync(new LoadingPage());
        }

        private async Task RemoverLoading()
        {
            await Navigation.PopModalAsync();
        }
    }
}
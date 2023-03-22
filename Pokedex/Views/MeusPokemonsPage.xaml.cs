using Pokedex.Models;
using Pokedex.ViewModels;
using Pokedex.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Pokedex.Views
{
    public partial class MeusPokemonsPage : ContentPage
    {
        MeusPokemonsViewModel _viewModel;

        public MeusPokemonsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new MeusPokemonsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}
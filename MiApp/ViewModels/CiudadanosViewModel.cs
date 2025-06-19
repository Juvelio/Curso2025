using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Entidades.Models;
using MiApp.Services;
using MiApp.Views;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.ViewModels
{
    public partial class CiudadanosViewModel : ObservableObject
    {
        private readonly CiudadanoService _ciudadanoService;
        private readonly GeneroService _generoService;

        [ObservableProperty]
        bool _isBusy;

        [ObservableProperty]
        private List<Ciudadano> _ciudadanos = [];

        [ObservableProperty]
        private List<Genero> _generos = [];

        public CiudadanosViewModel(CiudadanoService ciudadanoService, GeneroService generoService)
        {
            _ciudadanoService = ciudadanoService;
            _generoService = generoService;
        }

        Ciudadano ciudadano = new();
        bool mostrarFormulario = false;


        public async void OnAppearing()
        {
            await Cargar();
        }

        async Task Cargar()
        {
            try
            {
                IsBusy = true;

                Ciudadanos = await _ciudadanoService.ObtenerCiudadanosAsync();
                Generos = await _generoService.ObtenerGenerosAsync();
            }
            catch (Exception)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }       
        

        [RelayCommand]
        async Task NavegarCiudadano(Ciudadano ciudadano)
        {
            await Shell.Current.GoToAsync($"{nameof(CiudadanoPage)}?id={ciudadano.Id}");
        }

        [RelayCommand]
        async Task AgregarCiudadano()
        {
            await Shell.Current.GoToAsync(nameof(CiudadanoPage));
        }
    }
}

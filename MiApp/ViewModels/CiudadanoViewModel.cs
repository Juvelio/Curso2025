using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Entidades.Models;
using MiApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.ViewModels
{
    public partial class CiudadanoViewModel : ObservableObject, IQueryAttributable
    {
        [ObservableProperty]
        private Ciudadano _ciudadano;
        [ObservableProperty]
        private List<Genero> _generos = [];

        [ObservableProperty]
        private int _selectedIndex = -1;

        private readonly CiudadanoService _ciudadanoService;
        private readonly GeneroService _generoService;
        public CiudadanoViewModel(CiudadanoService ciudadanoService, GeneroService generoService)
        {
            _ciudadanoService = ciudadanoService;
            _generoService = generoService;
        }
        public async void ApplyQueryAttributes(IDictionary<string, object> query)
        {
            await LoadTaskAsync(query);
            Generos = await _generoService.ObtenerGenerosAsync();

            SelectedIndex = Generos.FindIndex(p => p.Id == Ciudadano.GeneroId);
        }

        private async Task LoadTaskAsync(IDictionary<string, object> query)
        {
            int ciudadanoId = 0;

            if (query.ContainsKey("id"))
            {
                ciudadanoId = Convert.ToInt32(query["id"]);
                Ciudadano = await _ciudadanoService.ObtenerPorIdAsync(ciudadanoId);
            }
            else
            {
                Ciudadano = new Ciudadano();
            }
        }

        [RelayCommand]
        async Task Guardar()
        {
            if (Ciudadano is null)
                return;

            var genero = Generos[SelectedIndex];
            Ciudadano.GeneroId = genero?.Id ?? 0;

            if (Ciudadano.Id == 0)
                await _ciudadanoService.CrearAsync(Ciudadano);
            else
                await _ciudadanoService.ActualizarAsync(Ciudadano);

            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task Eliminar()
        {
            if (Ciudadano.Id == 0)
                return;

            await _ciudadanoService.EliminarAsync(Ciudadano.Id);
            await Shell.Current.GoToAsync("..");
        }

        [RelayCommand]
        async Task Cancelar()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

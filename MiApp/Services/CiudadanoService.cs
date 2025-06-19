using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Services
{
    public class CiudadanoService
    {
        private readonly HttpClient _httpClient;
        public CiudadanoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Ciudadano>> ObtenerCiudadanosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Ciudadano>>("api/v1/ciudadanos");
        }
        public async Task<Ciudadano> ObtenerPorIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Ciudadano>($"api/v1/ciudadanos/{id}");
        }

        public async Task CrearAsync(Ciudadano persona)
        {
            await _httpClient.PostAsJsonAsync("api/v1/ciudadanos", persona);
        }

        public async Task ActualizarAsync(Ciudadano persona)
        {
            await _httpClient.PutAsJsonAsync($"api/v1/ciudadanos/{persona.Id}", persona);
        }

        public async Task EliminarAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/v1/ciudadanos/{id}");
        }

    }
}

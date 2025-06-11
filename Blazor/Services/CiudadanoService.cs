using System.Net.Http;
using System;
using System.Net.Http.Json;
using System.Text.Json;
using Entidades.Models;

namespace Blazor.Services
{
    public class CiudadanoService
    {
        private readonly HttpClient _http;

        public CiudadanoService(HttpClient http)
        {
            _http = http;
        }

        private JsonSerializerOptions OpcionesSerializacionJson => new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        public async Task<List<Ciudadano>> ObtenerPersonasAsync()
        {
            return await _http.GetFromJsonAsync<List<Ciudadano>>("api/v1/ciudadanos");
            //var respuestaHttp = await _http.GetAsync("api/v1/ciudadanos");
            //if (respuestaHttp.IsSuccessStatusCode)
            //{
            //    //OBTENER EL JSON 
            //    var json = await respuestaHttp.Content.ReadAsStringAsync();
            //    var citas = JsonSerializer.Deserialize<List<Ciudadano>>(json, OpcionesSerializacionJson);
            //    return citas;
            //}
            //else
            //{
            //    return new List<Ciudadano>();
            //}
        }

        public async Task<Ciudadano> ObtenerPorIdAsync(int id)
        {
            return await _http.GetFromJsonAsync<Ciudadano>($"api/v1/ciudadanos/{id}");
        }

        public async Task CrearAsync(Ciudadano persona)
        {
            await _http.PostAsJsonAsync("api/v1/ciudadanos", persona);
        }

        public async Task ActualizarAsync(Ciudadano persona)
        {
            await _http.PutAsJsonAsync($"api/v1/ciudadanos/{persona.Id}", persona);
        }

        public async Task EliminarAsync(int id)
        {
            await _http.DeleteAsync($"api/v1/ciudadanos/{id}");
        }
    }
}

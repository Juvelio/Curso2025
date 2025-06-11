using Entidades.Models;
using System.Net.Http.Json;

namespace Blazor.Services
{
    public class GeneroService
    {
        private readonly HttpClient _http;

        public GeneroService(HttpClient http)
        {
             _http = http;
        }

        public async Task<List<Genero>> ObtenerGenerosAsync()
        {
            return await _http.GetFromJsonAsync<List<Genero>>("api/v1/generos");
        }
    }
}

using Entidades.Models;
using System.Net.Http.Json;

namespace Blazor.Services
{
    public class GeneroService
    {
        private readonly HttpClient _httpClient;
        public GeneroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Genero>> ObtenerGenerosAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Genero>>("api/v1/generos");
        }
    }
}

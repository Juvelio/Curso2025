using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MiApp.Services
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

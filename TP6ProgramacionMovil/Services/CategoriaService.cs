using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;
using TP6ProgramacionMovil.Models;

namespace TP6ProgramacionMovil.Services
{
    public class CategoriaService
    {
        private readonly HttpClient _http;

        public CategoriaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<CategoriaResponse>> ObtenerCategoriasAsync()
        {
            var categorias =
                await _http.GetFromJsonAsync<
                    List<CategoriaResponse>>(
                    "api/CategoriasProductos"
                );

            return categorias?
                .Where(c => c.Activo)
                .ToList()
                ?? new();
        }
    }
}
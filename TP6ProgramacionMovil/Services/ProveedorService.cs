using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;
using TP6ProgramacionMovil.Models;

namespace TP6ProgramacionMovil.Services
{
    public class ProveedorService
    {
        private readonly HttpClient _http;

        public ProveedorService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ProveedorResponse>> ObtenerProveedoresAsync()
        {
            var respuesta =
                await _http.GetFromJsonAsync<
                    RespuestaPaginada<ProveedorResponse>>(
                    "api/Proveedores?pagina=1&tamanoPagina=50&ordenarPor=nombre"
                );

            return respuesta?.Datos
                .Where(p => p.Activo)
                .ToList()
                ?? new();
        }
    }
}
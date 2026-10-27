using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;
using TP6ProgramacionMovil.Models;

namespace TP6ProgramacionMovil.Services
{
    public class ClienteService
    {
        private readonly HttpClient _http;

        public ClienteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ClienteResponse>> ObtenerClientesAsync()
        {
            var respuesta =
                await _http.GetFromJsonAsync<
                    RespuestaPaginada<ClienteResponse>>(
                    "api/Clientes?pagina=1&tamanoPagina=50&ordenarPor=nombre"
                );

            return respuesta?.Datos ?? new();
        }
    }
}
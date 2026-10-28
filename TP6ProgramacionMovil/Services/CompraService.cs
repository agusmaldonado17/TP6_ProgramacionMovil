using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;
using TP6ProgramacionMovil.Models;

namespace TP6ProgramacionMovil.Services
{
    public class CompraService
    {
        private readonly HttpClient _http;

        public CompraService(HttpClient http)
        {
            _http = http;
        }

        public async Task<CompraResultado> RegistrarCompraAsync(
            CompraRequest compra)
        {
            var response =
                await _http.PostAsJsonAsync(
                    "api/Compras",
                    compra
                );

            if (!response.IsSuccessStatusCode)
            {
                var error =
                    await response.Content.ReadAsStringAsync();

                throw new Exception(
                    string.IsNullOrWhiteSpace(error)
                        ? "No se pudo registrar la entrada."
                        : error
                );
            }

            var resultado =
                await response.Content
                    .ReadFromJsonAsync<CompraResultado>();

            if (resultado == null)
            {
                throw new Exception(
                    "La respuesta de la entrada no es válida."
                );
            }

            return resultado;
        }
  

        public async Task<RespuestaPaginada<CompraResponse>?> ObtenerComprasAsync(
        int pagina = 1,
        int tamanoPagina = 20)
            {
                return await _http.GetFromJsonAsync<
                    RespuestaPaginada<CompraResponse>>(
                    $"api/Compras?pagina={pagina}&tamanoPagina={tamanoPagina}&ordenarPor=fecha_desc"
                );
            }

    }
}
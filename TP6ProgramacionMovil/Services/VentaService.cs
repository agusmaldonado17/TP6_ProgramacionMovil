using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;
using TP6ProgramacionMovil.Models;

namespace TP6ProgramacionMovil.Services
{
    public class VentaService
    {
        private readonly HttpClient _http;

        public VentaService(HttpClient http)
        {
            _http = http;
        }

        public async Task<VentaResultado> RegistrarVentaAsync(
            VentaRequest venta)
        {
            var response =
                await _http.PostAsJsonAsync(
                    "api/Ventas",
                    venta
                );

            if (!response.IsSuccessStatusCode)
            {
                var error =
                    await response.Content.ReadAsStringAsync();

                throw new Exception(
                    string.IsNullOrWhiteSpace(error)
                        ? "No se pudo registrar la venta."
                        : error
                );
            }

            var resultado =
                await response.Content
                    .ReadFromJsonAsync<VentaResultado>();

            if (resultado == null)
            {
                throw new Exception(
                    "La respuesta de la venta no es válida."
                );
            }

            return resultado;
        }

        public async Task<RespuestaPaginada<VentaResponse>?> ObtenerVentasAsync(
        int pagina = 1,
        int tamanoPagina = 20,
        string buscar = "")
        {
            var url =
                $"api/Ventas?pagina={pagina}&tamanoPagina={tamanoPagina}&ordenarPor=fecha_desc";

            if (!string.IsNullOrWhiteSpace(buscar))
            {
                url += $"&buscar={Uri.EscapeDataString(buscar)}";
            }

            return await _http.GetFromJsonAsync<
                RespuestaPaginada<VentaResponse>>(url);
        }
    }
}
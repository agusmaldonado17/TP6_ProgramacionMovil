using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;
using TP6ProgramacionMovil.Models;

namespace TP6ProgramacionMovil.Services
{
    public class ReporteService
    {
        private readonly HttpClient _http;

        public ReporteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<byte[]> ObtenerPdfAsync(string tipo)
        {
            var response =
                await _http.GetAsync(
                    $"api/Reportes/{tipo}"
                );

            if (!response.IsSuccessStatusCode)
            {
                var error =
                    await response.Content.ReadAsStringAsync();

                throw new Exception(
                    string.IsNullOrWhiteSpace(error)
                        ? "No se pudo generar el reporte."
                        : error
                );
            }

            return await response.Content
                .ReadAsByteArrayAsync();
        }


        public async Task<string> EnviarReporteAsync(
            string email,
            string tipo)
        {
            var request = new EnviarReporteRequest
            {
                Email = email,
                TipoReporte = tipo
            };

            var response =
                await _http.PostAsJsonAsync(
                    "api/Reportes/enviar",
                    request
                );

            if (!response.IsSuccessStatusCode)
            {
                var error =
                    await response.Content.ReadAsStringAsync();

                throw new Exception(
                    string.IsNullOrWhiteSpace(error)
                        ? "No se pudo enviar el reporte."
                        : error
                );
            }

            var resultado =
                await response.Content
                    .ReadFromJsonAsync<MensajeResponse>();

            return resultado?.Mensaje
                ?? "Reporte enviado correctamente.";
        }
    }
}
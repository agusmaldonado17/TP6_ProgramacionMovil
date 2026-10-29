using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;
using TP6ProgramacionMovil.Models;

namespace TP6ProgramacionMovil.Services
{
    public class ProductoService
    {
        private readonly HttpClient _http;

        public ProductoService(HttpClient http)
        {
            _http = http;
        }

        public async Task<RespuestaPaginada<ProductoResponse>?> ObtenerProductosAsync(
            int pagina = 1,
            int tamanoPagina = 20,
            string buscar = "")
        {
            var url =
                $"api/Productos?pagina={pagina}&tamanoPagina={tamanoPagina}";

            if (!string.IsNullOrWhiteSpace(buscar))
            {
                url += $"&buscar={Uri.EscapeDataString(buscar)}";
            }

            var response = await _http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                return null;

            return await response.Content
                .ReadFromJsonAsync<RespuestaPaginada<ProductoResponse>>();
        }

        public string ObtenerUrlImagen(ProductoResponse producto)
        {
            var imagen = producto.Imagenes.FirstOrDefault();

            if (imagen == null || string.IsNullOrWhiteSpace(imagen.Url))
                return "";

            if (Uri.IsWellFormedUriString(
                    imagen.Url,
                    UriKind.Absolute))
            {
                return imagen.Url;
            }

            return new Uri(
                _http.BaseAddress!,
                imagen.Url
            ).ToString();
        }


        public async Task<ProductoResponse> CrearProductoAsync(
    ProductoRequest producto)
        {
            var response =
                await _http.PostAsJsonAsync(
                    "api/Productos",
                    producto
                );

            if (!response.IsSuccessStatusCode)
            {
                var error =
                    await response.Content.ReadAsStringAsync();

                throw new Exception(
                    string.IsNullOrWhiteSpace(error)
                        ? "No se pudo crear el producto."
                        : error
                );
            }

            var creado =
                await response.Content
                    .ReadFromJsonAsync<ProductoResponse>();

            if (creado == null)
            {
                throw new Exception(
                    "La respuesta del producto no es válida."
                );
            }

            return creado;
        }
    }
}
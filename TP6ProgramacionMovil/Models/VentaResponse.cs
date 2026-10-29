using System;
using System.Collections.Generic;
using System.Text;

namespace TP6ProgramacionMovil.Models
{
    public class VentaResponse
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public string NombreCliente { get; set; } = "";
        public string NombreUsuario { get; set; } = "";

        public List<DetalleVentaResponse> Detalles { get; set; } = new();
    }
}

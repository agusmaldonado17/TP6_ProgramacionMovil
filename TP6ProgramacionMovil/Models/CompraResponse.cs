using System;
using System.Collections.Generic;
using System.Text;

namespace TP6ProgramacionMovil.Models
{
    public class CompraResponse
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }

        public int ProveedorId { get; set; }
        public string ProveedorNombre { get; set; } = "";

        public int UsuarioId { get; set; }
        public string UsuarioNombre { get; set; } = "";

        public List<DetalleCompraResponse> Detalles { get; set; } = new();
    }
}
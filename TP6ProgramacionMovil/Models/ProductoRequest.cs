using System;
using System.Collections.Generic;
using System.Text;

namespace TP6ProgramacionMovil.Models
{
    public class ProductoRequest
    {
        public string Nombre { get; set; } = "";
        public string? Descripcion { get; set; }

        public decimal PrecioVenta { get; set; }

        public int StockActual { get; set; }

        public int PuntoReposicion { get; set; }

        public int StockMaximo { get; set; }

        public bool Activo { get; set; } = true;

        public int CategoriaProductoId { get; set; }
    }
}
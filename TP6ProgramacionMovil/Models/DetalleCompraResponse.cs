using System;
using System.Collections.Generic;
using System.Text;

namespace TP6ProgramacionMovil.Models
{
    public class DetalleCompraResponse
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public string ProductoNombre { get; set; } = "";
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
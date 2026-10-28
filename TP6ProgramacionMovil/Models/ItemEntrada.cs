using System;
using System.Collections.Generic;
using System.Text;

namespace TP6ProgramacionMovil.Models
{
    public class ItemEntrada
    {
        public ProductoResponse Producto { get; set; } = new();

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal =>
            Cantidad * PrecioUnitario;
    }
}
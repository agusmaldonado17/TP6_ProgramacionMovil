using System;
using System.Collections.Generic;
using System.Text;

namespace TP6ProgramacionMovil.Models
{
    public class ItemCarrito
    {
        public ProductoResponse Producto { get; set; } = new();

        public int Cantidad { get; set; }

        public decimal Subtotal =>
            Producto.PrecioVenta * Cantidad;
    }
}
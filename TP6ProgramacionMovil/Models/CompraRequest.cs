using System;
using System.Collections.Generic;
using System.Text;

namespace TP6ProgramacionMovil.Models
{
    public class CompraRequest
    {
        public int ProveedorId { get; set; }

        public List<DetalleCompraRequest> Detalles { get; set; } = new();
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace TP6ProgramacionMovil.Models
{
    public class VentaRequest
    {
        public int ClienteId { get; set; }

        public List<DetalleVentaRequest> Detalles { get; set; } = new();
    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace TP6ProgramacionMovil.Models
{
    public class VentaResultado
    {
        public string Mensaje { get; set; } = "";
        public int VentaId { get; set; }
        public decimal Total { get; set; }
    }
}
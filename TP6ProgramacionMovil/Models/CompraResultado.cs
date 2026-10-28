using System;
using System.Collections.Generic;
using System.Text;

namespace TP6ProgramacionMovil.Models
{
    public class CompraResultado
    {
        public string Mensaje { get; set; } = "";
        public int CompraId { get; set; }
        public decimal Total { get; set; }
    }
}
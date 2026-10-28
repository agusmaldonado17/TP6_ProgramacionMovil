using System;
using System.Collections.Generic;
using System.Text;

namespace TP6ProgramacionMovil.Models
{
    public class EnviarReporteRequest
    {
        public string Email { get; set; } = "";
        public string TipoReporte { get; set; } = "";
    }
}
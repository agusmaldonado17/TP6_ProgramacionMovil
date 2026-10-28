using System;
using System.Collections.Generic;
using System.Text;

namespace TP6ProgramacionMovil.Models
{
    public class ProveedorResponse
    {
        public int Id { get; set; }
        public string RazonSocial { get; set; } = "";
        public string? Cuit { get; set; }
        public string? Telefono { get; set; }
        public string? Email { get; set; }
        public string? Direccion { get; set; }
        public bool Activo { get; set; }
    }
}
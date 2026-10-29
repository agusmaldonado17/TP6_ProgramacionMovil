using System;
using System.Collections.Generic;
using System.Text;

namespace TP6ProgramacionMovil.Models
{
    public class CategoriaResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = "";
        public string? Descripcion { get; set; }
        public bool Activo { get; set; }
    }
}
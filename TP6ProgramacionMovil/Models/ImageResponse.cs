using System;
using System.Collections.Generic;
using System.Text;

namespace TP6ProgramacionMovil.Models
{
    public class ImagenResponse
    {
        public int Id { get; set; }
        public string NombreOriginal { get; set; } = "";
        public string Url { get; set; } = "";
        public string TipoContenido { get; set; } = "";
        public long TamanoBytes { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
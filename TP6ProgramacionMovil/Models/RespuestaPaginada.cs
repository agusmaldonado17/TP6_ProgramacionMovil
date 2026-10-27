using System;
using System.Collections.Generic;
using System.Text;

namespace TP6ProgramacionMovil.Models
{
    public class RespuestaPaginada<T>
    {
        public int PaginaActual { get; set; }

        public int TamanoPagina { get; set; }

        public int TotalRegistros { get; set; }

        public int TotalPaginas { get; set; }

        public bool TienePaginaAnterior { get; set; }

        public bool TienePaginaSiguiente { get; set; }

        public List<T> Datos { get; set; } = new();
    }
}
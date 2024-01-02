using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Shared.DTOs
{
    public class PaginacionDTO
    {
        public int Id { get; set; }
        public int Pagina { get; set; } = 1;
        public int RegistrosPorPagina { get; set; } = 10;

        public string? Filtro { get; set; }
    }
}

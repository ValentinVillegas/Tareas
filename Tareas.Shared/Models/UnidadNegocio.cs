using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Shared.Models
{
    public class UnidadNegocio
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener más de {1} caracteres.")]
        public string Nombre { get; set; } = null!;

        public char Cancelo { get; set; } = '0';

        public ICollection<Equipo> Equipos { get; set; } = null!;

        public int CantEquipos => Equipos == null ? 0 : Equipos.Count;
    }
}

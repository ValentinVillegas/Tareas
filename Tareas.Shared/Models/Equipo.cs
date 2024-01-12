using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Shared.Models
{
    public class Equipo
    {
        public int Id { get; set; }

        [Display(Name = "Clave")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(30, ErrorMessage = "El campo {0} no debe tener más de {1} caracteres.")]
        public string CveEquipo { get; set; } = null!;

        [Display(Name = "Descripción")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener más de {1} caracteres.")]
        public string Descripcion { get; set; } = null!;

        public char Cancelo { get; set; } = '0';
        public char Estatus { get; set; } = '0';

        public int UnidadNegocioId { get; set; }
        public UnidadNegocio UnidadNegocio { get; set; } = null!;

        public int RubroId { get; set; }
        public Rubro Rubro { get; set; } = null!;
    }
}

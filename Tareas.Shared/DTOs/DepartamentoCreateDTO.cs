using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tareas.Shared.Enums;

namespace Tareas.Shared.DTOs
{
    public class DepartamentoCreateDTO
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener más de {1} caracteres")]
        public string Nombre { get; set; } = null!;

        public EstatusDepartamento Cancelo { get; set; } = EstatusDepartamento.Activo;
    }
}

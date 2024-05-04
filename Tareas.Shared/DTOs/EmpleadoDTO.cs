using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tareas.Shared.Enums;

namespace Tareas.Shared.DTOs
{
    public class EmpleadoDTO
    {
        public int Id { get; set; }

        [Display(Name = "Clave de empleado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(10, ErrorMessage = "El campo {0} no debe tener más de {1} caracteres.")]
        public string CveEmpleado { get; set; } = null!;

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener más de {1} caracteres.")]
        public string Nombre { get; set; } = null!;

        public EstatusEmpleado Cancelo { get; set; } = EstatusEmpleado.Activo;

        public int DepartamentoId { get; set; }

        public string Departamento { get; set; } = null!;
    }
}

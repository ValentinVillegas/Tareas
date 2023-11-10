using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tareas.Shared.Models
{
    public class Departamento
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener más de {1} caracteres")]
        public string Nombre { get; set; } = null!;

        public ICollection<Empleado>? Empleados { get; set; }

        [Display(Name = "Cantidad Empleados")]
        public int CantEmpleados => Empleados == null ? 0 : Empleados.Count;
    }
}

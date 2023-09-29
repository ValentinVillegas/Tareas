using System.ComponentModel.DataAnnotations;

namespace Tareas.Shared.Models
{
    public class RubroEncargados
    {
        public int Id { get; set; }
        public int RubroId { get; set; }

        [Display(Name = "Número de empleado")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(6, ErrorMessage = "El campo {0} no debe tener más de {1} caracteres.")]
        public string CveEmpleado { get; set; } = null!;

        [Display(Name = "Correo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener más de {1} caracteres.")]
        public string Correo { get; set; } = null!;

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "El campo {0} es requerido.")]
        [MaxLength(20, ErrorMessage = "El campo {0} no debe tener más de {1} caracteres")]
        public string Password { get; set; } = null!;
        public bool EsJefe { get; set; } = false;
    }
}

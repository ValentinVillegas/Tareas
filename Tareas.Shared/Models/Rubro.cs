using System.ComponentModel.DataAnnotations;

namespace Tareas.Shared.Models
{
    public class Rubro
    {
        public int Id { get; set; }

        [Display(Name = "Rubro")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [MaxLength(100, ErrorMessage = "El campo {0} no debe tener más de {1} caracteres.")]
        public string Nombre { get; set; } = null!;

        public byte Cancelo { get; set; }
        public Int64 Folio { get; set; }

        public ICollection<RubroEncargados>? Encargados { get; set; }

        [Display(Name = "Cantidad Trabajadores")]
        public int CantTrabajadores => Encargados == null || Encargados.Count == 0 ? 0 : Encargados.Count;
    }
}

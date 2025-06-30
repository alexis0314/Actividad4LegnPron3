using System.ComponentModel.DataAnnotations;

namespace Actividad4LegnProg3.Models
{
    public class MateriasViewModel
    {
        [Required]
        public int Codigo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El nombre está incompleto")]
        public string Nombre { get; set;}

        [Required]
        public int Credito { get; set; }

        [Required]
        [StringLength(1, MinimumLength = 10, ErrorMessage = "La Carrera debe tener entre 1 y 10 caracteres.")]
        public string Carrera { get; set; }

        public virtual ICollection<CalificacionesViewModel> Calificaciones { get; set; }
    }
}

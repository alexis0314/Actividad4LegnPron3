using System.ComponentModel.DataAnnotations;

namespace Actividad4LegnProg3.Models
{
    public class CalificacionesViewModel
    {
        [Required(ErrorMessage = "La matrícula es obligatoria")]
        public int MatriculaEstudiantes { get; set; }

        [Required]
        public int CodigoMateria { get; set; }

        [Required]
        [StringLength(0, MinimumLength = 100, ErrorMessage = "La Nota debe tener entre 0 y 100 caracteres.")]
        public decimal Nota { get; set; }

        [Required]
        public int Periodo { get; set; }

    }
}

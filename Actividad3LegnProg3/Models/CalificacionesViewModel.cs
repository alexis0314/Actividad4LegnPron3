using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Actividad4LegnProg3.Models
{
    public class CalificacionesViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "La matrícula es obligatoria")]
        public int MatriculaEstudiantes { get; set; }

        [Required]
        public int CodigoMateria { get; set; }

        [Required]
        [StringLength(0, MinimumLength = 100, ErrorMessage = "La Nota debe tener entre 0 y 100 caracteres.")]
        [Precision(5, 2)]
        public decimal Nota { get; set; }

        [Required]
        public int Periodo { get; set; }

        public virtual EstudianteViewModel Estudiante { get; set; }
        public virtual MateriasViewModel Materia { get; set; }
    }
}

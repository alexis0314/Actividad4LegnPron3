using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Actividad4LegnProg3.Models
{
    public class CalificacionesViewModel
    {
        public int Id { get; set; }

        [Required]
        public int EstudianteId { get; set; }

        [Required]
        public int MateriaId { get; set; }

        [Required]
        [Range(0, 100)]
        [Column(TypeName = "decimal(5,2)")]
        public decimal Nota { get; set; }

        [Required]
        public string Periodo { get; set; }

        public EstudianteViewModel Estudiante { get; set; }
        public MateriasViewModel Materia { get; set; }
    }
}

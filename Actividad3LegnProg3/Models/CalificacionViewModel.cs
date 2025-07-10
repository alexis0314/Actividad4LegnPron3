using System.ComponentModel.DataAnnotations;

namespace Actividad4LegnProg3.Models
{
    public class CalificacionViewModel
    {
        public int Id { get; set; }

        [Required]
        public string MatriculaEstudiante { get; set; }

        [Required]
        public int CodigoMateria { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal Nota { get; set; }

        [Required]
        public string Periodo { get; set; }
    }
}

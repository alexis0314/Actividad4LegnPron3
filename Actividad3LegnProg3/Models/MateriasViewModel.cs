using System.ComponentModel.DataAnnotations;

namespace Actividad4LegnProg3.Models
{
    public class MateriasViewModel
    {
        [Key]
        [Required]
        public int Codigo { get; set; }

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Los créditos deben estar entre 1 y 10.")]
        public int Creditos { get; set; }

        [Required]
        public string Carrera { get; set; }
    }
}

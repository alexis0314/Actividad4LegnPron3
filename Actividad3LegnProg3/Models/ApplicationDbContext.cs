using Microsoft.EntityFrameworkCore;

namespace Actividad4LegnProg3.Models
    
{
    public class ApplicationDbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<EstudianteViewModel> Estudiantes { get; set; }
        public DbSet<MateriasViewModel> Materias { get; set; }
        public DbSet<CalificacionesViewModel> Calificaciones { get; set; }
    }
}

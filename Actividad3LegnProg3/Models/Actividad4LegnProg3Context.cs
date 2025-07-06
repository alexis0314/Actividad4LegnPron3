using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Actividad4LegnProg3.Models;

public partial class Actividad4LegnProg3Context : DbContext
{
    public Actividad4LegnProg3Context()
    {
    }

    public Actividad4LegnProg3Context(DbContextOptions<Actividad4LegnProg3Context> options)
        : base(options)
    {
    }
    public DbSet<EstudianteViewModel> Estudiantes { get; set; }
    public DbSet<MateriasViewModel> Materias { get; set; }
    public DbSet<CalificacionesViewModel> Calificaciones { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

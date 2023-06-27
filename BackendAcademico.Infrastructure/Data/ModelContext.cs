using System;
using System.Collections.Generic;
using BackendAcademico.Core.Entities;
using BackendAcademico.Infrastructure.Data.Configuraciones;
using Microsoft.EntityFrameworkCore;

namespace BackendAcademico.Infrastructure.Data;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Estudiante> Estudiantes { get; set; }

    public virtual DbSet<Inscripcion> Inscripcions { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("ACADEMICO")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.ApplyConfiguration(new EstudianteConfiguration());

        modelBuilder.ApplyConfiguration(new InscripcionConfiguration());

        modelBuilder.ApplyConfiguration(new MateriaConfiguration());

    }

   
}

using System;
using System.Collections.Generic;
using BackendAcademico.Core.Entities;
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

    public virtual DbSet<Inscripcion> Inscripcion { get; set; }

    public virtual DbSet<Materium> Materia { get; set; }

   // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //      => optionsBuilder.UseOracle("User Id=ACADEMICO;Password=123456;Data Source=localhost:1521/xe;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("ACADEMICO")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Estudiante>(entity =>
        {
            entity.HasKey(e => e.Idestudiante);

            entity.ToTable("ESTUDIANTE");

            entity.Property(e => e.Idestudiante)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDESTUDIANTE");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("APELLIDOS");
            entity.Property(e => e.Ci)
                .HasColumnType("NUMBER")
                .HasColumnName("CI");
            entity.Property(e => e.Fechanacimiento)
                .HasColumnType("DATE")
                .HasColumnName("FECHANACIMIENTO");
            entity.Property(e => e.Nombres)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("NOMBRES");
        });

        modelBuilder.Entity<Inscripcion>(entity =>
        {
            entity.HasKey(e => e.Idinscripcion);

            entity.ToTable("INSCRIPCION");

            entity.Property(e => e.Idinscripcion)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDINSCRIPCION");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            entity.Property(e => e.Idestudiante)
                .HasColumnType("NUMBER")
                .HasColumnName("IDESTUDIANTE");
            entity.Property(e => e.Idmateria)
                .HasColumnType("NUMBER")
                .HasColumnName("IDMATERIA");

            entity.HasOne(d => d.IdestudianteNavigation).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.Idestudiante)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INSCRIPCION_ESTUDIANTE");

            entity.HasOne(d => d.IdmateriaNavigation).WithMany(p => p.Inscripcions)
                .HasForeignKey(d => d.Idmateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_INSCRIPCION_MATERIA");
        });

        modelBuilder.Entity<Materium>(entity =>
        {
            entity.HasKey(e => e.Idmateria);

            entity.ToTable("MATERIA");

            entity.Property(e => e.Idmateria)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDMATERIA");
            entity.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.Sigla)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("SIGLA");
        });
       
    }

   
}

using BackendAcademico.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BackendAcademico.Infrastructure.Data.Configuraciones;

namespace BackendAcademico.Infrastructure.Data.Configuraciones
{
    public class InscripcionConfiguration : IEntityTypeConfiguration<Inscripcion>
    {
        public void Configure(EntityTypeBuilder<Inscripcion> builder)
        {
            builder.HasKey(e => e.Idinscripcion);

            builder.ToTable("INSCRIPCION");

            builder.Property(e => e.Idinscripcion)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDINSCRIPCION");
            builder.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
            builder.Property(e => e.Idestudiante)
                .HasColumnType("NUMBER")
                .HasColumnName("IDESTUDIANTE");
            builder.Property(e => e.Idmateria)
                .HasColumnType("NUMBER")
                .HasColumnName("IDMATERIA");

            builder.HasOne(d => d.IdestudianteNavigation)
                   .WithMany()
                   .HasForeignKey(d => d.Idestudiante)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_INSCRIPCION_ESTUDIANTE");

            builder.HasOne(d => d.IdmateriaNavigation)
                   .WithMany()
                   .HasForeignKey(d => d.Idmateria)
                   .OnDelete(DeleteBehavior.ClientSetNull)
                   .HasConstraintName("FK_INSCRIPCION_MATERIA");
        }
    }
}

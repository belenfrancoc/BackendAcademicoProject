using BackendAcademico.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendAcademico.Infrastructure.Data.Configuraciones
{
    public class EstudianteConfiguration : IEntityTypeConfiguration<Estudiante>
    {
        public void Configure(EntityTypeBuilder<Estudiante> builder)
        {
            builder.HasKey(e => e.Idestudiante);

            builder.ToTable("ESTUDIANTE");

            builder.Property(e => e.Idestudiante)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDESTUDIANTE");
            builder.Property(e => e.Apellidos)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("APELLIDOS");
            builder.Property(e => e.Ci)
                    .HasColumnType("NUMBER")
                    .HasColumnName("CI");
            builder.Property(e => e.Fechanacimiento)
                    .HasColumnType("DATE")
                    .HasColumnName("FECHANACIMIENTO");
            builder.Property(e => e.Nombres)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("NOMBRES");

        }
   
    }
}

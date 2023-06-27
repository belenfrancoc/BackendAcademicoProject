using BackendAcademico.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendAcademico.Infrastructure.Data.Configuraciones
{
    public class MateriaConfiguration : IEntityTypeConfiguration<Materium>
    {
        public void Configure(EntityTypeBuilder<Materium> builder)
        {
            builder.HasKey(e => e.Idmateria);

            builder.ToTable("MATERIA");

            builder.Property(e => e.Idmateria)
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMBER")
                .HasColumnName("IDMATERIA");
            builder.Property(e => e.Nombre)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            builder.Property(e => e.Sigla)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("SIGLA");
        }
    }
}

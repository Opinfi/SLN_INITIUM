using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configuraciones
{
    public class ConfigurationPersona : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.ToTable(NameEntities.Persona, SchemasDataBase.Catalogo);

            builder.HasKey(c => c.IdPersona);

            builder.Property(c => c.Identificacion)
                                .HasMaxLength(350)
                                .HasColumnType(TypeColumn.Varchar)
                                .IsRequired();

            builder.Property(c => c.Nombre)
                    .HasMaxLength(400)
                   .HasColumnType(TypeColumn.Varchar)
                   .IsRequired();
        }
    }
}

using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configuraciones
{
    public class ConfigurationCola : IEntityTypeConfiguration<Cola>
    {
        public void Configure(EntityTypeBuilder<Cola> builder)
        {
            builder.ToTable(NameEntities.Cola, SchemasDataBase.Catalogo);

            builder.HasKey(c => c.IdCola);

            builder.Property(c => c.Codigo)
                .HasMaxLength(25)
                .HasColumnType(TypeColumn.Varchar)
                .IsRequired();

            builder.Property(c => c.TiempoAtencion)
                .IsRequired();
        }
    }
}

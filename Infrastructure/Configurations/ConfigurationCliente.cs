using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configuraciones
{
    public class ConfigurationCliente : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable(NameEntities.Cliente, SchemasDataBase.Catalogo);

            builder.HasKey(c => c.IdCliente);
            builder.Property(c => c.Contrasena)
                .HasColumnType(TypeColumn.Varchar)
                .HasMaxLength(350);

           builder.HasOne(c => c.Persona)
                .WithMany()
                .HasForeignKey(c => c.PersonaId);

            
        }
    }
}

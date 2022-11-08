using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configuraciones
{
    public class ConfigurationBaseEntities : IEntityTypeConfiguration<BaseEntity>
    {

        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.Property(c => c.FechaRegistro)
                .IsRequired();

            builder.Property(c => c.UsuarioRegistro)
                   .HasColumnType(TypeColumn.Varchar)
                   .HasMaxLength(350)
                   .IsRequired();

            builder.Property(c => c.UsuarioModificacion)
                   .HasColumnType(TypeColumn.Varchar)
                   .HasMaxLength(350);

            builder.Property(c => c.UsuarioAnulacion)
                   .HasColumnType(TypeColumn.Varchar)
                   .HasMaxLength(350);

            builder.Property(c => c.IpRegistro)
                   .HasColumnType(TypeColumn.Varchar)
                   .HasMaxLength(25);

            builder.Property(c => c.IpModificacion)
                   .HasColumnType(TypeColumn.Varchar)
                   .HasMaxLength(25);

            builder.Property(c => c.IpAnulacion)
                   .HasColumnType(TypeColumn.Varchar)
                   .HasMaxLength(25);
        }
    }
}

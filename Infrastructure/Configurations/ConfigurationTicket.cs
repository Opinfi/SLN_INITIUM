using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructura.Configuraciones
{
    public class ConfigurationTicket : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.ToTable(NameEntities.Ticket, SchemasDataBase.General);

            builder.HasKey(c => c.IdTicket);

            builder.Property(c => c.Codigo)
                   .HasColumnType(TypeColumn.Varchar)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.HasOne(c => c.Cliente)
                .WithMany(c => c.Tickets)
                .HasForeignKey(c => c.ClienteId);

            builder.HasOne(c => c.Cola)
                .WithMany(c => c.Tickets)
                .HasForeignKey(c => c.ColaId);
        }
    }
}

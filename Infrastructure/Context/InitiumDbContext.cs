using Application.Interfaces;
using Domain.Entities;
using Infraestructura.Configuraciones;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{ 
    public class InitiumDbContext : DbContext, IInitiumDbContext
    {
        public InitiumDbContext(DbContextOptions<InitiumDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual  DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<Cola> Colas { get; set; } = null!;
        public virtual DbSet<Ticket> Tickets { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ConfigurationCliente());
            modelBuilder.ApplyConfiguration(new ConfigurationCola());
            modelBuilder.ApplyConfiguration(new ConfigurationPersona());
            modelBuilder.ApplyConfiguration(new ConfigurationTicket());
            base.OnModelCreating(modelBuilder);
        }
    }
}

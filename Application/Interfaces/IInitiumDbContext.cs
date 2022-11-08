using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IInitiumDbContext
    {
        DbSet<Persona> Personas { get; set; }
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Cola> Colas { get; set; }
        DbSet<Ticket> Tickets { get; set; }
    }
}

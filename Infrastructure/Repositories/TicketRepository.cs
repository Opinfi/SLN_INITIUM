using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TicketRepository : Repository<Ticket>, ITicketRepository
    {
        private InitiumDbContext _context;
        public TicketRepository(InitiumDbContext context) : base(context)
        {
            this._context = context;

        }
        public async Task<IEnumerable<Ticket>> GetAllTickets()
        {
            return  _context.Tickets
                 .Where(x => x.Estado && x.EstadoTickets != Domain.Enums.EstadoTickets.Finalizado)
                 .Include(x => x.Cliente)
                 .Include(x => x.Cliente.Persona)
                 .Include(x => x.Cola).AsEnumerable();
        }
    }
}

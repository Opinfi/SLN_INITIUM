using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<IEnumerable<Ticket>> GetAllTickets();
    }
}

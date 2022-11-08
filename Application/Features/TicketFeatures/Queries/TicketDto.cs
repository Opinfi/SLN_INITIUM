using Domain.Entities;
using Domain.Enums;

namespace Application.Features.TicketFeatures.Queries
{
    public class TicketDto
    {
        public TicketDto(Ticket ticket ) {
            IdTicket = ticket.IdTicket;
            CodigoTicket = ticket.Codigo;
            Cola = ticket?.Cola?.Codigo;
            Cliente = $"{ticket?.Cliente?.Persona?.Identificacion}-{ticket?.Cliente?.Persona?.Nombre}";
            FechaTicket = ticket.FechaTicket;
            EstadoTickets = ticket.EstadoTickets;
        }
        public long IdTicket { get; set; }
        public string? CodigoTicket { get; set; }
        public string? Cola { get; set; }
        public string? Cliente { get; set; }
        public DateTime FechaTicket { get; set; }
        public EstadoTickets EstadoTickets { get; set; }
    }
}

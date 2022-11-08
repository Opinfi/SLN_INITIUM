using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Ticket: BaseEntity
    {
        public long IdTicket { get; set; }
        public string? Codigo { get; set; }
        public long Serie { get; set; }
        public long ColaId { get; set; }
        public long ClienteId { get; set; }
        public DateTime FechaTicket { get; set; }
        public EstadoTickets EstadoTickets { get; set; }
        public virtual Cola? Cola { get; set; }
        public virtual Cliente? Cliente { get; set; }

    }
}

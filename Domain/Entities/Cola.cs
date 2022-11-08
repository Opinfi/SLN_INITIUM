using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Cola : BaseEntity
    {
        public long IdCola { get; set; }
        public string? Codigo { get; set; }
        public long TiempoAtencion { get; set; }
        public virtual IEnumerable<Ticket>? Tickets { get; set; }
    }
}

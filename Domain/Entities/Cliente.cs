using Domain.Common;

namespace Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public long IdCliente { get; set; }
        public string? Contrasena { get; set; }
        public long PersonaId { get; set; }
        public virtual Persona? Persona { get; set; }
        public virtual IEnumerable<Ticket>? Tickets { get; set; }
    }
}

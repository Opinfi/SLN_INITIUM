using Domain.Common;

namespace Domain.Entities
{
    public class Persona : BaseEntity
    {
        public long IdPersona { get; set; }
        public string? Identificacion { get; set; }
        public string? Nombre { get; set; }
    }
}

using System.Runtime.Serialization;
namespace Services.Interops.Request
{
    public class CreateTickets
    {
        [DataMember(Name = "nombre")]
        public string? Nombre { get; set; }
        [DataMember(Name = "identificacion")]
        public string? Identificacion { get; set; }
        [DataMember(Name = "cola")]
        public string? Cola { get; set; }
        [DataMember(Name = "cola2")]
        public string? Cola2 { get; set; }
    }
}

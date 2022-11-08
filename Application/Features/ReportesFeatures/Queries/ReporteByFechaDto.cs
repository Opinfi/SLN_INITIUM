using Domain.Entities;

namespace Application.Features.ReportesFeatures.Queries
{
    public class ReporteByFechaDto
    {

        public ReporteByFechaDto() { }
        public ReporteByFechaDto(Ticket ticket) {
            FechaTransaccion = ticket.FechaTicket.ToString();
            Cliente = $"{ticket?.Cliente?.Persona?.Identificacion}-{ticket?.Cliente?.Persona?.Nombre}";
            Cola = ticket?.Cola?.Codigo;
            EstadoTickets = ticket?.EstadoTickets.ToString();
        }
        public string? FechaTransaccion { get; set; }
        public string? Cliente { get; set; }
        public string? Cola { get; set; }
        public string? EstadoTickets { get; set; }
    }
}

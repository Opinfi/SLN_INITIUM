using Application.Interfaces;
using MediatR;

namespace Application.Features.ReportesFeatures.Queries
{
    public class GetReportesByFechaQuery : IRequest<IEnumerable<ReporteByFechaDto>?>
    {
        public DateTime? FechaInico { get; set; }
        public DateTime? FechaFin { get; set; }

        public class GetReportesByFechaQueryHandler : IRequestHandler<GetReportesByFechaQuery, IEnumerable<ReporteByFechaDto>?>
        {
            private readonly ITicketRepository _ticketRepository;

            public GetReportesByFechaQueryHandler(
                ITicketRepository ticketRepository
                )
            {
                _ticketRepository = ticketRepository;
            }

            public async Task<IEnumerable<ReporteByFechaDto>?> Handle(GetReportesByFechaQuery query, CancellationToken cancellationToken)
            {
                List<ReporteByFechaDto>? reporte = null;

                var tickets = await _ticketRepository.GetAllAsync();
                if (tickets?.Any()==false)
                    return reporte;

                tickets = tickets?.Where(x => x.Estado);

                if(query.FechaInico != null && query.FechaFin != null)
                 tickets = tickets?.Where(x => x.FechaTicket.Date >= query.FechaInico?.Date
                                          && x.FechaTicket.Date <= query.FechaFin?.Date);
                reporte = new List<ReporteByFechaDto>();
                reporte = tickets?.Select(x=> new ReporteByFechaDto(x)).ToList();

                return reporte;
            }
        }
    }
}

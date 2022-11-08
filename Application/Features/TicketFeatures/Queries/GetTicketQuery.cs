using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.TicketFeatures.Queries
{
    public class GetTicketQuery : IRequest<TicketDto?>
    {
        public long Id { get; set; }

        public class GetTicketByIdQueryHandler : IRequestHandler<GetTicketQuery, TicketDto?>
        {
            private readonly ITicketRepository _ticketRepository;
            private readonly IMapper _mapper;

            public GetTicketByIdQueryHandler(ITicketRepository ticketRepository,
                IMapper mapper)
            {
                _ticketRepository = ticketRepository;
                _mapper = mapper;
            }
            public async Task<TicketDto?> Handle(GetTicketQuery query, CancellationToken cancellationToken)
            {
                TicketDto? movimientoDto = null;

                var movimiento = await _ticketRepository.GetIdAsync(query.Id);

                if (movimiento != null)
                    movimientoDto = _mapper.Map<TicketDto>(movimiento);

                return movimientoDto;
            }
        }
    }
}

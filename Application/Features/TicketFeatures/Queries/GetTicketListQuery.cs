using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.TicketFeatures.Queries
{
    public class GetTicketListQuery : IRequest<IEnumerable<TicketDto>?>
    {
        public class GetAllTicketQueryHandler : IRequestHandler<GetTicketListQuery, IEnumerable<TicketDto>?>
        {
            private readonly ITicketRepository _ticketRepository;
            private readonly IMapper _mapper;

            public GetAllTicketQueryHandler(ITicketRepository ticketRepository,
                IMapper mapper)
            {
                _ticketRepository = ticketRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<TicketDto>?> Handle(GetTicketListQuery query, CancellationToken cancellationToken)
            {
                IEnumerable<TicketDto>? ticketsDto = null;

                var tickets = await _ticketRepository.GetAllTickets();

                if (tickets != null)
                    ticketsDto = tickets.Select(x => new TicketDto(x));

                return ticketsDto;
            }
        }
    }
}

using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.ClienteFeatures.Queries
{
    public class GetClienteQuery : IRequest<ClienteDto?>
    {
        public long Id { get; set; }
        public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteQuery, ClienteDto?>
        {
            private readonly ITicketRepository _clienteRepository;
            private readonly IMapper _mapper;

            public GetClienteByIdQueryHandler(ITicketRepository clienteRepository,
                IMapper mapper)
            {
                this._clienteRepository = clienteRepository;
                this._mapper = mapper;
            }
            public async Task<ClienteDto?> Handle(GetClienteQuery query, CancellationToken cancellationToken)
            {
                ClienteDto? clienteDto = null;

                var cliente = await _clienteRepository.GetIdAsync(query.Id);
                
                if (cliente != null)
                    clienteDto = _mapper.Map<ClienteDto>(cliente);

                return clienteDto;
            }
        }
    }
}

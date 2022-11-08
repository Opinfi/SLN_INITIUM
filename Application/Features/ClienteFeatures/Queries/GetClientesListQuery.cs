using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.ClienteFeatures.Queries
{
    public class GetClientesListQuery : IRequest<IEnumerable<ClienteDto>?>
    {
        public class GetAllClientesQueryHandler : IRequestHandler<GetClientesListQuery, IEnumerable<ClienteDto>?>
        {
            private readonly ITicketRepository _clienteRepository;
            private readonly IMapper _mapper;

            public GetAllClientesQueryHandler(ITicketRepository clienteRepository,
                IMapper mapper)
            {
                this._clienteRepository = clienteRepository;
                this._mapper =  mapper;
            }

            public async Task<IEnumerable<ClienteDto>?> Handle(GetClientesListQuery query, CancellationToken cancellationToken)
            {
                IEnumerable<ClienteDto>? clientesDto = null;

                var clientes = await _clienteRepository.GetAllAsync();

                if (clientes != null)
                    clientesDto = _mapper.Map<IEnumerable<ClienteDto>>(clientes);

                return clientesDto;
            }
        }

    }
}

using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.ColaFeatures.Queries
{
    public class GetColaQuery : IRequest<ColaDto?>
    {
        public long Id { get; set; }
        public class GetColaByIdQueryHandler : IRequestHandler<GetColaQuery, ColaDto?>
        {
            private readonly IColaRepository _colaRepository;
            private readonly IMapper _mapper;

            public GetColaByIdQueryHandler(IColaRepository colaRepository,
                IMapper mapper)
            {
                _colaRepository = colaRepository;
                _mapper = mapper;
            }
            public async Task<ColaDto?> Handle(GetColaQuery query, CancellationToken cancellationToken)
            {
                ColaDto? colaDto = null;

                var cola = await _colaRepository.GetIdAsync(query.Id);

                if (cola != null)
                    colaDto = _mapper.Map<ColaDto>(cola);

                return colaDto;
            }
        }
    }
}

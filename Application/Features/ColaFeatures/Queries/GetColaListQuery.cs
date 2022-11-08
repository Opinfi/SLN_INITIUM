using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.Features.ColaFeatures.Queries
{
    public class GetColaListQuery : IRequest<IEnumerable<ColaDto>?>
    {
        public class GetAllColaQueryHandler : IRequestHandler<GetColaListQuery, IEnumerable<ColaDto>?>
        {
            private readonly IColaRepository _colaRepository;
            private readonly IMapper _mapper;

            public GetAllColaQueryHandler(IColaRepository colaRepository,
                IMapper mapper)
            {
                _colaRepository = colaRepository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ColaDto>?> Handle(GetColaListQuery query, CancellationToken cancellationToken)
            {
                IEnumerable<ColaDto>? colaDto = null;

                var cola = await _colaRepository.GetAllAsync();

                if (cola != null)
                    colaDto = _mapper.Map<IEnumerable<ColaDto>>(cola);

                return colaDto;
            }
        }

    }
}

using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.Features.ColaFeatures.Commands.CreateCola
{
    public class CreateColaCommand : IRequest<string>
    {
        public string? Codigo { get; set; }
        public long TiempoAtencion { get; set; }
        public bool Estado { get; set; }

        public class CreateColaCommandHandler : IRequestHandler<CreateColaCommand, string>
        {
            private readonly IColaRepository _colaRepository;
            private readonly IMapper _mapper;

            public CreateColaCommandHandler(IColaRepository colaRepository,
                IMapper mapper)
            {
                _colaRepository = colaRepository;
                _mapper = mapper;
            }

            public async Task<string> Handle(CreateColaCommand command, CancellationToken cancellationToken)
            {
                string result=string.Empty;
                try
                {
                    var cola = _mapper.Map<Cola>(command);
                    cola.FechaRegistro =  DateTime.Now;
                    await _colaRepository.AddAsync(cola);
                    result ="Ok";                  
                }
                catch (Exception e)
                {
                    result=e.Message;   
                }
                return result;
            }
        }
    }
}

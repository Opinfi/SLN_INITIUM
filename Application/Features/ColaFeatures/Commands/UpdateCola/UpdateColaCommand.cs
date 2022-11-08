using Application.Interfaces;
using Domain.Enums;
using MediatR;

namespace Application.Features.ColaFeatures.Commands.UpdateCola
{
    public class UpdateColaCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string? Codigo { get; set; }
        public long TiempoAtencion { get; set; }


        public class UpdateColaCommandHandler : IRequestHandler<UpdateColaCommand, long>
        {
            private readonly IColaRepository _colaRepository;

            public UpdateColaCommandHandler(IColaRepository colaRepository)
            {
                _colaRepository = colaRepository;
            }

            public async Task<long> Handle(UpdateColaCommand command, CancellationToken cancellationToken)
            {
                var cola = await _colaRepository.GetIdAsync(command.Id);

                if (cola == null)
                {
                    return default;
                }
                else
                {
                    cola.Codigo = command.Codigo;
                    cola.TiempoAtencion = command.TiempoAtencion;
                    await _colaRepository.Update(cola);
                    return cola.IdCola;
                }
            }
        }
    }
}

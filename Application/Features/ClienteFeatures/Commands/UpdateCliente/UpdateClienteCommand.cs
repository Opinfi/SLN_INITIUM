using Application.Interfaces;
using MediatR;

namespace Application.Features.ClienteFeatures.Commands.UpdateCliente
{
    public class UpdateClienteCommand : IRequest<long>
    {
        public long Id { get; set; }
        public string? Nombre { get; set; }
        public string? Identificacion { get; set; }


        public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, long>
        {
            private readonly IClienteRepository _clienteRepository;
            
            public UpdateClienteCommandHandler(IClienteRepository clienteRepository)
            {
                this._clienteRepository = clienteRepository;
            }

            public async Task<long> Handle(UpdateClienteCommand command, CancellationToken cancellationToken)
            {
                var cliente = await _clienteRepository.GetIdAsync(command.Id);

                if (cliente == null)
                {
                    return default;
                }
                else
                {
                    cliente.Contrasena = $"{command.Nombre}{command.Identificacion}";
                    await _clienteRepository.Update(cliente);
                    return cliente.IdCliente;
                }
            }
        }
    }
}

using Application.Features.TicketFeatures.Commands;
using Application.Interfaces;
using Domain.Enums;
using MediatR;

namespace Application.Features.TicketFeatures.Queries
{
    public class GetNewCreateTicket : IRequest<CreateTicketCommand?>
    {
        public class GetNewCreateTicketHandler : IRequestHandler<GetNewCreateTicket, CreateTicketCommand?>
        {
            private readonly ITicketRepository _ticketRepository;
            private readonly IColaRepository _colaRepository;

            public GetNewCreateTicketHandler(ITicketRepository ticketRepository,
                IColaRepository colaRepository)
            {
                this._ticketRepository = ticketRepository;
                this._colaRepository = colaRepository;
            }

            public async Task<CreateTicketCommand?> Handle(GetNewCreateTicket query, CancellationToken cancellationToken)
            {
                var command = new CreateTicketCommand();

                int numCola1 = NumeroColas.Cola1.GetHashCode();
                int numCola2 = NumeroColas.Cola2.GetHashCode();
                string codigoCola1 = numCola1.ToString().PadLeft(4, '0');
                string codigoCola2 = numCola2.ToString().PadLeft(4, '0');

                var colas = await _colaRepository.FindAsync(x => x.Estado);
                if (colas.Count() == 0)
                {
                    command.Cola = $"{codigoCola1}-0000001";
                    command.Cola2 = $"{codigoCola2}-0000001";
                }
                var fechaTicket = DateTime.Now;
                var listaTickets = await _ticketRepository.FindAsync(x => x.Estado && x.FechaTicket.Date==fechaTicket.Date  );
                if (listaTickets.Count() == 0)
                {
                    command.Cola = $"{codigoCola1}-0000001";
                    command.Cola2 = $"{codigoCola2}-0000001";
                }
                else
                {
                    foreach (var item in colas)
                    {
                        long codigoT = 0;
                        if (item.Codigo == codigoCola1)
                        {
                            
                            if (listaTickets.Any(x => x.ColaId == item.IdCola))
                            {
                                codigoT = listaTickets.Where(x => x.ColaId == item.IdCola).Select(x => x.Serie).Max() + 1;
                            }
                            else
                                codigoT = 1;
                            command.Cola = $"{codigoCola1}-{codigoT.ToString().PadLeft(7, '0')}";
                        }
                        if (item.Codigo == codigoCola2)
                        {
                            if (listaTickets.Any(x => x.ColaId == item.IdCola))
                            {
                                codigoT = listaTickets.Where(x => x.ColaId == item.IdCola).Select(x => x.Serie).Max() + 1;
                            }
                            else
                                codigoT = 1;
                            command.Cola2 = $"{codigoCola2}-{codigoT.ToString().PadLeft(7, '0')}";
                        }
                    }
                }
                return command;
            }
        }
    }
}

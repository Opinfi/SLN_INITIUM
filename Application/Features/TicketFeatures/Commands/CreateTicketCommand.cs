using Application.Features.TicketFeatures.Queries;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.Features.TicketFeatures.Commands
{
    public class CreateTicketCommand : IRequest<string>
    {
        public string? Nombre { get; set; }
        public string? Identificacion { get; set; }
        public string? Cola { get; set; }
        public string? Cola2 { get; set; }

        public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, string>
        {
            private readonly IConfiguration _configuration;
            private readonly IClienteRepository _clienteRepository;
            private readonly IPersonaRepository _personaRepository;
            private readonly IColaRepository _colaRepository;
            private readonly ITicketRepository _ticketRepository;
            private readonly IMapper _mapper;

            public CreateTicketCommandHandler(IConfiguration configuration,
                IClienteRepository clienteRepository,
                IPersonaRepository personaRepository,
                IColaRepository colaRepository,
                ITicketRepository ticketRepository,
                IMapper mapper
            )
            {
                this._ticketRepository = ticketRepository;
                this._clienteRepository = clienteRepository;
                this._personaRepository = personaRepository;
                this._colaRepository = colaRepository;         
                this._configuration = configuration;
                this._mapper = mapper;
                
            }

            public async Task<string> Handle(CreateTicketCommand command, CancellationToken cancellationToken)
            {
                if(string.IsNullOrEmpty(command.Nombre))
                    return "Debe ingresar el nombre";
                if (string.IsNullOrEmpty(command.Identificacion))
                    return "Debe ingresar el id";

                var fechaTicket= DateTime.Now;
                var ticket = _mapper.Map<Ticket>(command);
                var colas = await _colaRepository.FindAsync(x=> x.Estado);
                if (colas != null)
                {
                    var listaTickets = await _ticketRepository.FindAsync(x => x.Estado &&
                                        x.EstadoTickets != Domain.Enums.EstadoTickets.Finalizado 
                                        && x.FechaTicket.Date == fechaTicket.Date);

                    var cola =  AssignCola(listaTickets,colas);
                    if(cola == null)
                        return "No se le asigno ninguna cola";
                    ticket.ColaId = cola.IdCola;
                    ticket.Serie = CreateSerie(ticket.ColaId, listaTickets);
                    ticket.Codigo = CreateCodigo(ticket.Serie);
                }
                else
                    return "No se encontraron colas para asignar";
                var clientes = await _clienteRepository.FindAsync(x => x.Persona.Identificacion.Trim()== command.Identificacion.Trim());
                if (clientes != null)
                {
                    var cliente = await CreateCliente(command.Identificacion, command.Nombre);
                    ticket.ClienteId = cliente.IdCliente;
                }
                ticket.EstadoTickets = Domain.Enums.EstadoTickets.Ingresado;
                ticket.FechaTicket = fechaTicket;
                ticket.FechaRegistro = DateTime.Now;
                ticket.Estado = true;
                await _ticketRepository.AddAsync(ticket);
                return "Ok";
            }

            private static Cola AssignCola(IEnumerable<Ticket> listaTickets, IEnumerable<Cola> colas)
            {
                Cola cola = new();

                if(listaTickets.Count()>0)
                {
                    var ultimosTickets = new List<TicketsColaDto>();
                    foreach (var item in colas)
                    {
                      var ultimo = listaTickets.Where(x=> x.ColaId== item.IdCola)
                        .GroupBy(x => new 
                        {
                            x.FechaTicket,
                            x.ColaId,
                            TiempoCola= x.Cola?.TiempoAtencion.GetHashCode()??0
                        })
                        .Select(x => new TicketsColaDto
                        {
                            Fecha=x.Key.FechaTicket.AddMinutes(x.Key.TiempoCola),
                            IdCola=x.Key.ColaId,
                        }).OrderByDescending(x=> x.Fecha).FirstOrDefault();
                        if(ultimo!=null)
                        ultimosTickets.Add(ultimo);
                    }
                    if(ultimosTickets.Count()== colas.Count()) {
                        var id = ultimosTickets.OrderBy(x => x.Fecha).FirstOrDefault().IdCola;
                        cola = colas.FirstOrDefault(x => x.IdCola == id);
                    }               
                    else
                    {
                        var idsColas = ultimosTickets.Select(x => x.IdCola).ToArray();
                        cola = colas.OrderBy(x => x.TiempoAtencion.GetHashCode()).FirstOrDefault(x => !idsColas.Contains(x.IdCola));
                    }
                        
                }
                else
                {
                    cola = colas.OrderBy(x => x.TiempoAtencion.GetHashCode()).FirstOrDefault();
                }
                return cola;
            }
            private async Task<Persona> CreatePersona(string id, string nombre)
            {
                Persona persona = new()
                {
                    Identificacion = id,
                    Nombre = nombre,
                    Estado = true,
                    FechaRegistro = DateTime.Now,
                    
                };
                await _personaRepository.AddAsync(persona);
                return persona;
            }
            private async Task<Cliente> CreateCliente(string id, string nombre)
            {
                var persona = await CreatePersona(id, nombre);
                Cliente cliente = new()
                {
                    Contrasena = $"{nombre}{id}",
                    PersonaId = persona.IdPersona,
                    Estado = true,
                    FechaRegistro = DateTime.Now,
                };
                await _clienteRepository.AddAsync(cliente);
                return cliente;
            }
            private static long CreateSerie(long idCola, IEnumerable<Ticket> listaTickets)
            {   
                if(listaTickets.Count()==0)
                     return 1;
                if(listaTickets.Any(x => x.ColaId == idCola))
                return listaTickets.Where(x => x.ColaId == idCola).Select(x=> x.Serie).Max() + 1;
                else 
                    return 1;
            }
            private static string CreateCodigo(long serie)
            {
                var serieString = serie.ToString();
                return serieString.PadLeft(7, '0');
            }
        }      
    }
}

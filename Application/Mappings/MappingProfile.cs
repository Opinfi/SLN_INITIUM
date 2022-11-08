using Application.Features.ClienteFeatures.Commands.CreateCliente;
using Application.Features.ClienteFeatures.Queries;
using Application.Features.ColaFeatures.Commands.CreateCola;
using Application.Features.ColaFeatures.Queries;
using Application.Features.TicketFeatures.Commands;
using Application.Features.TicketFeatures.Queries;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateColaCommand, Cola>();
            CreateMap<Cola, ColaDto>();
            CreateMap<ColaDto, Cola>();

            CreateMap<CreateTicketCommand, Ticket>();
            CreateMap<Ticket, TicketDto>();
            CreateMap<TicketDto, Ticket>();

            CreateMap<CreateClienteCommand, Cliente>();
            CreateMap<Cliente, ClienteDto>();
            CreateMap<ClienteDto, Cliente>();


        }
    }
}

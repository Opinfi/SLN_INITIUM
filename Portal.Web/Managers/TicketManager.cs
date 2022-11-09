using Portal.Web.Models.Ticket;
using Services.Interops;
using Services.Interops.Request;

namespace Portal.Web.Managers
{
    public class TicketManager
    {
        private readonly TicketsServices _ticketsServices;

        public TicketManager()
        {
            this._ticketsServices = new TicketsServices();
        }

        public async Task<CreateTicketViewModel> SincronizandoDatosTickets()
        {
            var peticion = await _ticketsServices.GetCreateTicket();
            var view = new CreateTicketViewModel();          
            if (peticion != null && peticion?.Cola != null)
            {
                view.Cola = peticion?.Cola;
                view.Cola2 = peticion?.Cola2;
                view.Identificacion = peticion?.Identificacion;
                view.Nombre = peticion?.Nombre;
            }       
            return view;
        }

        public async Task<string> CreateTicket(CreateTicketViewModel model)
        {
            if (model != null)
            {
                var datos = new CreateTickets()
                {
                    Cola = model?.Cola,
                    Cola2 = model?.Cola2,
                    Identificacion = model?.Identificacion,
                    Nombre = model?.Nombre,
                };
                var peticion = await _ticketsServices.CreateTicket(datos);
                return peticion;
            }
            return "Error al grabar tickets";
        }

    }
}

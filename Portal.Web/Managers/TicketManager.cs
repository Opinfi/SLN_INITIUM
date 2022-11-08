using Portal.Web.Models.Ticket;
using Services.Interops;

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
            var view = new CreateTicketViewModel();
            var peticion = await _ticketsServices.GetCreateTicket();
            if (peticion != null && peticion?.Cola != null)
            {
                view.Cola = peticion?.Cola;
                view.Cola2 = peticion?.Cola2;
                view.Identificacion = peticion?.Identificacion;
                view.Nombre = peticion?.Nombre;
            }       
            return view;
        }
    }
}

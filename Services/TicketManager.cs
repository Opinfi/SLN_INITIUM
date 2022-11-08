using Services.Interops;

namespace Services
{
    public  class TicketManager
    {
        private readonly TicketsServices _ticketsServices;

        public TicketManager(TicketsServices ticketsServices)
        {
            this._ticketsServices = ticketsServices;
        }

        

    }
}

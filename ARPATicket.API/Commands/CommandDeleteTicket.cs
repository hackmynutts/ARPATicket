using ARPATicket.API.Services;

namespace ARPATicket.API.Commands
{
    public class CommandDeleteTicket : ICommand<bool>
    {
        private readonly ITicketServices _ticketService;
        private readonly int _ticketID;
        public CommandDeleteTicket(ITicketServices ticketService, int ticketID)
        {
            _ticketService = ticketService;
            _ticketID = ticketID;
        }
        public async Task<bool> Execute()
        {
            return await _ticketService.DeleteTicket(_ticketID);
        }
    }
}

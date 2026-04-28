using ARPATicket.API.DTO;
using ARPATicket.API.Services;

namespace ARPATicket.API.Commands
{
    public class CommandAddTicket : ICommand<TicketDTO>
    {
        private readonly ITicketServices _ticketServices;
        private readonly TicketAddDTO _ticketAddDTO;

        public CommandAddTicket(ITicketServices ticketServices, TicketAddDTO ticketAddDTO)
        {
            _ticketServices = ticketServices;
            _ticketAddDTO = ticketAddDTO;
        }

        public async Task<TicketDTO> Execute()
        {
            return await _ticketServices.AddTicket(_ticketAddDTO);
        }
    }
}

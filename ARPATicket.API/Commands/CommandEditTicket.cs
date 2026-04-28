using ARPATicket.API.DTO;
using ARPATicket.API.Services;

namespace ARPATicket.API.Commands
{
    public class CommandEditTicket : ICommand<TicketDTO>
    {
        private readonly ITicketServices _ticketServices;
        private readonly TicketEditDTO _ticketEditDTO;
        public CommandEditTicket(ITicketServices ticketServices, TicketEditDTO ticketEditDTO)
        {
            _ticketServices = ticketServices;
            _ticketEditDTO = ticketEditDTO;
        }
        public async Task<TicketDTO> Execute()
        {
            var updatedTicket = await _ticketServices.UpdateTicket(_ticketEditDTO);
            if (updatedTicket == null)
            {
                throw new Exception($"No se pudo actualizar el ticket con ID {_ticketEditDTO.ticketID}");
            }
            return updatedTicket;
        }
    }
}

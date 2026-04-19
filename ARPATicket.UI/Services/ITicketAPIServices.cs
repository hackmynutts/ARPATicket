using ARPATicket.UI.Models;

namespace ARPATicket.UI.Services
{
    public interface ITicketAPIServices
    {
        Task<List<TicketDTO>> GetAllTicketsAsync();
        Task<TicketDTO?> GetTicketByIDAsync(int ticketID);
        Task<TicketDTO?> CreateTicketAsync(TicketAddDTO newTicket);
        Task<TicketDTO?> UpdateTicketAsync(TicketEditDTO updatedTicket);
        Task<bool> DeleteTicketAsync(int ticketID);
    }
}

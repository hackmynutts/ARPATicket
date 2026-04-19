using ARPATicket.API.Models;

namespace ARPATicket.API.Repository
{
    public interface ITicketRepository
    {
        Task<List<Ticket>> GetAllTicketsAsync();
        Task<Ticket?> GetTicketByIdAsync(int id);
        Task<Ticket> CreateTicketAsync(Ticket ticket);
        Task<Ticket?> UpdateTicketAsync(Ticket ticket);
        Task<bool> DeleteTicketAsync(int id);
    }
}

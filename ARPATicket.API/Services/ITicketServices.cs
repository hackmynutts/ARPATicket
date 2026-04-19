using ARPATicket.API.DTO;

namespace ARPATicket.API.Services
{
    public interface ITicketServices
    {
        Task<List<TicketDTO>> GetAllTickets();
        Task<TicketDTO?> GetTicketById(int id);
        Task<TicketDTO> AddTicket(TicketAddDTO newTicket);
        Task<TicketDTO?> UpdateTicket(TicketEditDTO ticketEditDTO);
        Task<bool> DeleteTicket(int id);
    }
}

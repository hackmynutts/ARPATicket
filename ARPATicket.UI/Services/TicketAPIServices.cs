using ARPATicket.UI.Models;

namespace ARPATicket.UI.Services
{
    public class TicketAPIServices : ITicketAPIServices
    {
        private readonly HttpClient _httpClient;

        public TicketAPIServices(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("ARPATicketAPI");
        }

        public async Task<List<TicketDTO>> GetAllTicketsAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<List<TicketDTO>>("Ticket")
                ?? new List<TicketDTO>();
        }

        public async Task<TicketDTO?> GetTicketByIDAsync(int ticketID)
        {
            var response = await _httpClient
                .GetAsync($"Ticket/{ticketID}");
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content
                .ReadFromJsonAsync<TicketDTO>();
        }

        public async Task<TicketDTO?> CreateTicketAsync(TicketAddDTO newTicket)
        {
            var response = await _httpClient
                .PostAsJsonAsync("Ticket", newTicket);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content
                .ReadFromJsonAsync<TicketDTO>();
        }


        public async Task<TicketDTO?> UpdateTicketAsync(TicketEditDTO updatedTicket)
        {
            var response = await _httpClient
                .PutAsJsonAsync($"Ticket/{updatedTicket.ticketID}", updatedTicket);
            if (!response.IsSuccessStatusCode) return null;
            return await response.Content
                .ReadFromJsonAsync<TicketDTO>();
        }

        public async Task<bool> DeleteTicketAsync(int ticketID)
        {
            var response = await _httpClient
                .DeleteAsync($"Ticket/{ticketID}");
            return response.IsSuccessStatusCode;
        }
    }
}

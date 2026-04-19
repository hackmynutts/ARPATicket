using ARPATicket.UI.Models;
namespace ARPATicket.UI.Services
{
    public class UserAPIServices : IUserAPIServices
    {
        private readonly HttpClient _httpClient;

        public UserAPIServices(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("ARPATicketAPI");
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            return await _httpClient
                .GetFromJsonAsync<List<UserDTO>>("User")
                ?? new List<UserDTO>();
        }

        public async Task<UserDTO?> CreateUserAsync(UserAddDTO newUser)
        {
            var response = await _httpClient
                .PostAsJsonAsync("User", newUser);

            if (!response.IsSuccessStatusCode) return null;

            return await response.Content
                .ReadFromJsonAsync<UserDTO>();
        }
    }
}

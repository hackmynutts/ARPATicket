namespace ARPATicket.API.Services
{
    public class PriorityService
    {
        private readonly HttpClient _httpClient;

        public PriorityService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<int> GetAvatarIdAsync()
        {
            var response = await _httpClient
                .GetFromJsonAsync<AvatarResponse>("Avatar");

            return response!.avatarID;
        }

        public async Task<string> GetPriorityAsync(string description)
        {
            var response = await _httpClient
                .PostAsJsonAsync("Priority", new { Description = description });
            var result = await response.Content
                .ReadFromJsonAsync<PriorityResponse>();
            return result?.priority ?? "Media"; //default 
        }
    }

    record AvatarResponse(int avatarID, string imageUrl);
    record PriorityResponse(string priority);
}

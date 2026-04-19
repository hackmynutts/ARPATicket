using ARPATicket.UI.Models;

namespace ARPATicket.UI.Services
{
    public interface IUserAPIServices
    {
        Task<List<UserDTO>> GetAllUsersAsync();
        Task<UserDTO?> CreateUserAsync(UserAddDTO newUser);
    }
}

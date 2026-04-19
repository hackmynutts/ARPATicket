using ARPATicket.API.DTO;

namespace ARPATicket.API.Services
{
    public interface IUserServices
    {
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO?> GetUserById(int id);
        Task<UserDTO> AddUser(UserAddDTO newUser);
        Task<UserDTO> UpdateUser(UserDTO updatedUser);
        Task<bool> DeleteUser(int id);
    }
}

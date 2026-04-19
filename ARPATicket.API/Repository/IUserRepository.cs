namespace ARPATicket.API.Repository
{
    public interface IUserRepository
    {
        Task<List<Models.User>> GetAllUsersAsync();
        Task<Models.User?> GetUserByIdAsync(int id);
        Task<Models.User> CreateUserAsync(Models.User user);
        Task<Models.User?> UpdateUserAsync(Models.User user);
        Task<bool> DeleteUserAsync(int id);
    }
}

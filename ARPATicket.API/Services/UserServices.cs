using ARPATicket.API.DTO;
using ARPATicket.API.Models;
using ARPATicket.API.Repository;
using System.Net.Http;

namespace ARPATicket.API.Services
{
    public class UserServices : TemplateService<UserAddDTO, User, UserDTO>,IUserServices
    {
        private readonly IUserRepository _userRepository;
        private readonly PriorityService _priorityService;
        public UserServices(IUserRepository userRepository, PriorityService priorityService)
        {
            _userRepository = userRepository;
            _priorityService = priorityService;
        }

        //lista de usuarios
        public async Task<List<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return users.Select(u => new UserDTO
            {
                userID = u.userID,
                name = u.name,
                username = u.username,
                email = u.email,
                AvatarID = u.AvatarID
            }).ToList();
        }

        // Obtener un usuario por ID
        public async Task<UserDTO?> GetUserById(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return null;
            return new UserDTO
            {
                userID = user.userID,
                name = user.name,
                username = user.username,
                email = user.email,
                AvatarID = user.AvatarID
            };
        }

        // Agregar un nuevo usuario
        public async Task<UserDTO> AddUser(UserAddDTO newUser)
        {
            return await AddAsync(newUser);
        }

        // Actualizar un usuario existente
        public async Task<UserDTO?> UpdateUser(UserDTO updatedUser)
        {
            var existingUser = await _userRepository.GetUserByIdAsync(updatedUser.userID);

            var user = new User
            {
                userID = updatedUser.userID,
                name = updatedUser.name,
                username = updatedUser.username,
                email = updatedUser.email,
                AvatarID = updatedUser.AvatarID
            };
            var result = await _userRepository.UpdateUserAsync(user);
            if (result == null) return null;
            return new UserDTO
            {
                userID = result.userID,
                name = result.name,
                username = result.username,
                email = result.email,
                AvatarID = result.AvatarID
            };
        }

        // Eliminar un usuario por ID
        public async Task<bool> DeleteUser(int id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }

        //IMPLEMENTACION DE CLASES ABSTRACTAS DEL TEMPLATE METHOD
        protected override async Task<string> GetExternalDataAsync(UserAddDTO dto)
        {
            var avatarID = await _priorityService.GetAvatarIdAsync();
            return avatarID.ToString();
        }

        protected override User MapToModel(UserAddDTO dto, string externalData)
        {
            return new User
            {
                name = dto.name,
                username = dto.username,
                email = dto.email,
                AvatarID = int.Parse(externalData)
            };
        }

        protected override async Task<User> SaveAsync(User model)
        {
            return await _userRepository.CreateUserAsync(model);
        }

        protected override UserDTO MapToResultDTO(User model)
        {
            return new UserDTO
            {
                userID = model.userID,
                name = model.name,
                username = model.username,
                email = model.email,
                AvatarID = model.AvatarID
            };
        }
    }
}
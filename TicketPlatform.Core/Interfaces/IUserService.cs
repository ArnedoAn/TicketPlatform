using TicketPlatform.Core.DTOs;
using TicketPlatform.Core.Entities;

namespace TicketPlatform.Core.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetUserById(int id);

        Task<bool> UpdateUser(UsersPutDto userDto);

        Task<bool> DeleteUser(int id);

        Task<bool> CreateUser(UsersPostDto userDto);
    }
}

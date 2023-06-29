using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPlatform.Core.Entities;

namespace TicketPlatform.Core.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();

        Task<User> GetUserById(int id);

        Task<bool> UpdateUser(User user);

        Task<bool> DeleteUser(int id);

        Task<bool> CreateUser(User user);
    }
}

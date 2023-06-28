using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPlatform.Core.Entities;

namespace TicketPlatform.Core.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();

        Task<User> Get(int id);

        Task<bool> Create(User user);

        Task<bool> Update(User user);

        Task<bool> Delete(int id);
    }
}

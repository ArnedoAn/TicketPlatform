using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPlatform.Core.EntitiesS;

namespace TicketPlatform.Core.Interfaces
{
    public interface ITicketRespository
    {
        Task<IEnumerable<Ticket>> GetAll();

        Task<Ticket> Get(int id);

        Task<bool> Update(Ticket ticket);

        Task<int> Create(Ticket ticket);

        Task<bool> Delete(int id);
    }
}

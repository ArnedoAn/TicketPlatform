using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPlatform.Core.EntitiesS;

namespace TicketPlatform.Core.Interfaces
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetTickets();

        Task<Ticket> GetTicketById(int id);

        Task<bool> CreateTicket(Ticket ticket);

        Task<bool> UpdateTicket(Ticket ticket);

        Task<bool> DeleteTicket(int id);
    }
}

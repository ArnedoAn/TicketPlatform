using TicketPlatform.Core.DTOs;
using TicketPlatform.Core.EntitiesS;

namespace TicketPlatform.Core.Interfaces
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> GetTickets();

        Task<Ticket> GetTicketById(int id);

        Task<bool> CreateTicket(TicketsPostDto ticketDto);

        Task<bool> UpdateTicket(TicketsPutDto ticketDto);

        Task<bool> DeleteTicket(int id);
    }
}

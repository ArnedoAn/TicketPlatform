using TicketPlatform.Core.DTOs;
using TicketPlatform.Core.EntitiesS;
using TicketPlatform.Core.Interfaces;

namespace TicketPlatform.Core.Services
{
    public class TicketService : ITicketService
    {

        private readonly ITicketRespository _ticketRespository;

        public TicketService(ITicketRespository ticketRespository)
        {
            _ticketRespository = ticketRespository;
        }

        public async Task<bool> CreateTicket(TicketsPostDto ticketDto)
        {
            Ticket ticket = new Ticket
            {
                Description = ticketDto.Descripcion,
                Priority = ticketDto.Prioridad
            };

            return await _ticketRespository.Create(ticket);
        }

        public async Task<bool> DeleteTicket(int id)
        {
            return await _ticketRespository.Delete(id);
        }

        public async Task<Ticket> GetTicketById(int id)
        {
            return await _ticketRespository.Get(id);
        }

        public async Task<IEnumerable<Ticket>> GetTickets()
        {
            return await _ticketRespository.GetAll();
        }

        public async Task<bool> UpdateTicket(TicketsPutDto ticketDto)
        {
            Ticket ticket = new Ticket
            {
                Id = ticketDto.Id,
                Description = ticketDto.Descripcion,
                Priority = ticketDto.Prioridad
            };

            return await _ticketRespository.Update(ticket);
        }
    }
}

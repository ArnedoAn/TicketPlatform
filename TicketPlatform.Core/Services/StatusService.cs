using TicketPlatform.Core.Entities;
using TicketPlatform.Core.Interfaces;

namespace TicketPlatform.Core.Services
{
    public class StatusService : IStatusService
    {

        private readonly IStatusRepository _statusRepository;

        public StatusService(IStatusRepository statusRepository)
        {
            _statusRepository = statusRepository;
        }

        public async Task<IEnumerable<Status>> GetStatuses()
        {
            return await _statusRepository.GetAllStatus();
        }
    }
}

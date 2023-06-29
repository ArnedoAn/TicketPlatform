using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicketPlatform.Core.Entities;

namespace TicketPlatform.Core.Interfaces
{
    public interface IStatusService
    {
        Task<List<Status>> GetStatuses();
    }
}

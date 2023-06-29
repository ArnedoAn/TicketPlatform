using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPlatform.Core.DTOs
{
    public class TicketsPutDto : TicketsPostDto
    {
        public int Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketPlatform.Core.Entities
{
    public class User
    {
        public int Id { get; set; } = 1;
        public string Nombre { get; set; } = string.Empty;
        public string Cedula { get; set; } = string.Empty;
    }
}

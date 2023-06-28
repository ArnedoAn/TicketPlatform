using TicketPlatform.Core.EntitiesS;

namespace TicketPlatform.Core.Entities
{
    public class Assignments
    {
        public Assignments() { }
       
        public int id { get; set; } = 1;
        public Ticket Ticket { get; set; } = new Ticket();
        public User User { get; set; } = new User();

        public DateTime Date { get; set; } = DateTime.Now;

        public int Status { get; set; } = 1;
    }
}

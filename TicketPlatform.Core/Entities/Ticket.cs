
namespace TicketPlatform.Core.EntitiesS
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Descripcion { get; set; } = string.Empty;
        public string Prioridad { get; set; } = string.Empty;
    }
}

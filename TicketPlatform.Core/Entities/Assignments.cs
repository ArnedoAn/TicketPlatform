﻿using TicketPlatform.Core.EntitiesS;

namespace TicketPlatform.Core.Entities
{
    public class Assignments
    {
        public Assignments() { }
       
        public int Id { get; set; }
        public Ticket Ticket { get; set; } = new Ticket();
        public User User { get; set; } = new User();

        public DateTime Fecha { get; set; } = DateTime.Now;

        public Status Estado { get; set; } = new Status();
    }
}

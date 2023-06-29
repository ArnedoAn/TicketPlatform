using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketPlatform.Core.DTOs;
using TicketPlatform.Core.Interfaces;

namespace TicketPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketsController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTickets()
        {
            var TicketList = await _ticketService.GetTickets();

            if (TicketList.Count() > 0) { return Ok(TicketList); } else { return BadRequest("No hay Tickets..."); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var ticket = await _ticketService.GetTicketById(id);
            if (ticket.Id != 0) { return Ok(ticket); } else { return BadRequest("No existe dicho ticket"); }

        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(TicketsPostDto ticketDto)
        {
            var result = await _ticketService.CreateTicket(ticketDto);
            if (result) { return Ok("Creado correctamente"); } else { return BadRequest("No se pudo crear el ticket"); }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTicket(TicketsPutDto ticketDto)
        {
            var result = await _ticketService.UpdateTicket(ticketDto);
            if (result) { return Ok("Actualizdo correctamente"); } else { return BadRequest("No se pudo actualizar el ticket"); }
        }
    }
}

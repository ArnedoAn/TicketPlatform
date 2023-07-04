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

            if (TicketList.Count() > 0) { return Ok ( TicketList ); } else { return BadRequest(new { message = "No hay tickets disponibles" }); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketById(int id)
        {
            var ticket = await _ticketService.GetTicketById(id);
            if (ticket.Id != 0) { return Ok( ticket ); } else { return BadRequest(new { message = "Ticket no existente" }); }

        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(TicketsPostDto ticketDto)
        {
            var result = await _ticketService.CreateTicket(ticketDto);
            if (result != 0) { return Ok(result); } else { return BadRequest(new { message = "No se pudo crear ticket" }); }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTicket(TicketsPutDto ticketDto)
        {
            var result = await _ticketService.UpdateTicket(ticketDto);
            if (result) { return Ok(new { message = "Actualizado Correctamente" }); } else { return BadRequest(new { message = "No se pudo actualizar ticket" }); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var result = await _ticketService.DeleteTicket(id);
            if (result) { return Ok(new { message = "Eliminado Correctamente" }); } else { return BadRequest(new {message = "No se pudo eliminar ticket"}); } 
        }
    }
}

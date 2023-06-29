using Microsoft.AspNetCore.Mvc;
using TicketPlatform.Core.DTO;
using TicketPlatform.Core.DTOs;
using TicketPlatform.Core.Interfaces;

namespace TicketPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignmentsController : ControllerBase
    {
        private readonly IAssignmentService _assigmentService;
        public AssignmentsController(IAssignmentService assigmentService)
        {
            _assigmentService = assigmentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAssigment(int id)
        {
            var assigment = await _assigmentService.GetAssignment(id);
            if (assigment.Id == 0) { return Ok(assigment); } else { return BadRequest(); }
        }

        [HttpGet]
        public async Task<IActionResult> GetAssigments()
        {
            var assigments = await _assigmentService.GetAssignments();
            if (assigments.Count() > 0) { return Ok(assigments); }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAssigment([FromBody] AssignmentsPostDto assignmentDto)
        {
            var result = await _assigmentService.CreateAssigment(assignmentDto);
            if (result) { return Ok("Creado Correctamente"); } else { return BadRequest("Hubo un error..."); }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateAssignment([FromBody] AssignmentsPutDto assignmentDto)
        {
            Console.WriteLine(assignmentDto.Id);
            var result = await _assigmentService.UpdateAssigment(assignmentDto);
            if (result) { return Ok("Actualizado Correctamente"); } else { return BadRequest("Hubo un error..."); }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var result = await _assigmentService.DeleteAssigment(id);
            if (result) { return Ok("Eliminado Correctamente"); } else { return BadRequest("Hubo un error..."); }
        }
    }
}

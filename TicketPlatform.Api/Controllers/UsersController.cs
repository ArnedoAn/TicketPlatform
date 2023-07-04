using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketPlatform.Core.DTOs;
using TicketPlatform.Core.Interfaces;

namespace TicketPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            if (users.Count() > 0) { return Ok( users ); } else { return BadRequest(new { message = "No hay usuarios disponibles" }); }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            if (user.Id != 0) { return Ok( user ); } else { return BadRequest(new {message = "No existe usuario"}); }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UsersPostDto userDto)
        {

            var result = await _userService.CreateUser(userDto);

            if (result) { return Ok(new { message = "Creado Correctamente" }); } else { return BadRequest(new { message = "No se pudo crear" }); }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(UsersPutDto userDto)
        {
            
            var result = await _userService.UpdateUser(userDto);
            if (result) { return Ok(new { message = "Actualizado Correctamente" }); } else { return BadRequest(new { message = "No se pudo actualizar" }); }

        }

        //[HttpDelete]
        //public async Task<IActionResult> DeleteUser(int id)
        //{
        //    var result = await _userService.DeleteUser(id);
        //    if (result) { return Ok("Eliminado correctamente"); } else { return BadRequest("Hubo un error..."); }
        //}


    }
}

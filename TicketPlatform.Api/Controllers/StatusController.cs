﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketPlatform.Core.Interfaces;

namespace TicketPlatform.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStatus()
        {
            var statusList = await _statusService.GetStatuses();

            if (statusList.Any()) { return Ok(statusList); } else { return BadRequest(new {message = "Hubo un error..." }); }

        }
        
    }
}

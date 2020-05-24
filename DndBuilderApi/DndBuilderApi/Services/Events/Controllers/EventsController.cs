using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using PersonalAssistant.Services.Events.Managers;
using PersonalAssistant.Services.Sms.Domain;

namespace PersonalAssistant.Services.Events.Controllers
{
    [ApiController]
    [Route("/events")]
    public class EventsController : ControllerBase
    {
        private readonly ILogger<EventsController> _logger;
        private readonly IEventsManager _eventsManager;

        public EventsController(ILogger<EventsController> logger, IEventsManager eventsManager)
        {
            _logger = logger;
            _eventsManager = eventsManager;
        }

        [ProducesResponseType(typeof(Guid), 200)]
        [Produces("application/json")]
        [HttpPost]
        public async Task<IActionResult> PostAsync(SendSmsDto dto)
        {
            var result = await _eventsManager.InsertEventAsync(dto);

            if (result == Guid.Empty)
            {
                return BadRequest("Invalid phone number.");
            }

            return Ok(result);
        }

    }
}

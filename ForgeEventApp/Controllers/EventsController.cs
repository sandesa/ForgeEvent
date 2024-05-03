using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForgeEventApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventsController : ControllerBase
	{
		private readonly IEventRepository _eventRepository;

		public EventsController(IEventRepository eventsRepository)
		{
			_eventRepository = eventsRepository;
		}

		[HttpGet]
		public async Task<ActionResult<Event>> GetAllEvents()
		{
			var events = await _eventRepository.GetAllEventsAsync();

			if (events is null)
			{
				return NotFound();
			}
			return Ok(events);
		}
	}
}

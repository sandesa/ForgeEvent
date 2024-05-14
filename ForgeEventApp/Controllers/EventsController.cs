using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using ForgeEventApp.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ForgeEventApp.Controllers
{
	[ApiController]
	[Route("api/[controller]")]

	public class EventsController : ControllerBase
	{
		private readonly IEventRepository _eventRepository;

		public EventsController(IEventRepository eventsRepository)
		{
			_eventRepository = eventsRepository;
		}

		[HttpGet("allevents")]
		public async Task<ActionResult<Event>> GetAllEvents()
		{
			var events = await _eventRepository.GetAllEventsAsync();

			if (events is null)
			{
				return NotFound();
			}
			return Ok(events);
		}

		[HttpGet("categories")]
		public async Task<ActionResult<string>> GetCategories()
		{
			Dictionary<Category, string> categoryDictionary = await _eventRepository.GetCategoryAsync();
			IEnumerable<string> displayNames = categoryDictionary.Values;
			return Ok(displayNames);
		}
		[HttpGet("{id}")]
		public async Task<ActionResult<Event>> GetEventDetails(int id)
		{
			var eventDetatils = await _eventRepository.GetEventWithAdminDetailsAsync(id);

			return Ok(eventDetatils);
		}

		[HttpPost]
        public async Task CreateEvent(Event events)
        {
            await _eventRepository.CreateEventAsync(events);
        }
    }
}

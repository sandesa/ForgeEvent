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
		public async Task<ActionResult<IEnumerable<string>>> GetCategoriesDisplay()
		{
			IEnumerable<(Category, string)> categories = await _eventRepository.GetCategoryAsync();

			IEnumerable<string> categoryDisplay = categories.Select(c => c.Item2);

			return Ok(categoryDisplay);
		}
		[HttpGet("enums")]
        public async Task<ActionResult<IEnumerable<string>>> GetCategoriesEnum()
        {
            IEnumerable<(Category, string)> categories = await _eventRepository.GetCategoryAsync();

            IEnumerable<Category> categoryDisplay = categories.Select(c => c.Item1);

            return Ok(categoryDisplay);
        }
        [HttpGet("select/{category}")]
        public async Task<ActionResult<Category>> GetCategories(string category)
        {
            IEnumerable<(Category, string)> categories = await _eventRepository.GetCategoryAsync();

			var findCategory = categories.FirstOrDefault(c => c.Item2 == category);

			Category categoryDisplay = findCategory.Item1;

            return Ok(categoryDisplay);
        }

        [HttpGet("{id}")]
		public async Task<ActionResult<Event>> GetEventDetails(int id)
		{
			var eventDetatils = await _eventRepository.GetEventWithAdminDetailsAsync(id);

			return Ok(eventDetatils);
		}

		[HttpGet("search")]
		public async Task<ActionResult<IEnumerable<Event>>> EventSearch([FromQuery] Category category, [FromQuery] string? searchString)
		{
			var searchEvent = await _eventRepository.SearchEventAsync(category, searchString);

			return Ok(searchEvent);
		}

		[HttpPost("{events}")]
        public async Task<ActionResult<Event>> CreateEvent(Event events)
        {
            await _eventRepository.CreateEventAsync(events);

			return CreatedAtAction(nameof(GetEventDetails), new { id = events.Id }, events);
        }
    }
}

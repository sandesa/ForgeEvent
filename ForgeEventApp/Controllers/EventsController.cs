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

        [HttpGet("{id}")]
		public async Task<ActionResult<Event>> GetEventDetails(int id)
		{
			var eventDetatils = await _eventRepository.GetEventWithAdminDetailsAsync(id);

			return Ok(eventDetatils);
		}

        [HttpGet("ticket/{id}")]
        public async Task<ActionResult<int>> GetTicketAmount(int id)
        {
            var ticketAmount = await _eventRepository.GetTicketAmountAsync(id);

            return Ok(ticketAmount);
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
		[HttpDelete("delete/{id}")]
        public async Task<ActionResult<Event>> DeleteEvent(int id)
        {
			await _eventRepository.RemoveEventAsync(id);

            return NoContent();
        }

    }
}

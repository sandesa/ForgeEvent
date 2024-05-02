using ForgeEventApp.Data;
using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ForgeEventApp.Repositories
{
	public class EventRepository : IEventRepository
	{
		private readonly AppDbContext _context;

		public EventRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Event>> GetAllEventsAsync()
		{
			return await _context.Events.Select(e => e).ToListAsync();
		}

	}
}

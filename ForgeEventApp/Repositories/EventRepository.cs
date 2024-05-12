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

		public async Task<int> GetTicketAmountAsync(int id)
		{
			Event ev = await _context.Events.FindAsync(id);

			return ev?.TicketAmount ?? 0;
		}

		public async Task<decimal> GetTicketPriceAsync(int id)
		{
            Event ev = await _context.Events.FindAsync(id);

            return ev?.Price ?? 0;
        }
		public async Task<Event> GetEventByIdAsync(int eventId)
		{
			return await _context.Events.FirstOrDefaultAsync(e => e.Id == eventId);
		}
	}
}

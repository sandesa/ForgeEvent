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

		public async Task CreateEventAsync(Event events)
		{
			Event newEvent = new()
			{
				Name = events.Name,
				Address = events.Address,
				Description = events.Description,
				Category = events.Category,
				Price = events.Price,
				TicketAmount = events.TicketAmount,
				Date = events.Date,
				CreatedAt = events.CreatedAt,
				ImageUrl = events.ImageUrl,
			};
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
        }
	}
}

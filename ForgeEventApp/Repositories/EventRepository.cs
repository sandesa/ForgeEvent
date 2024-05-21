using ForgeEventApp.Data;
using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections;

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
        public async Task<IEnumerable<Event>> GetAllEventsPostedByUserAsync(int userId)
        {
            var events = await _context.Events.Where(e => e.User.Id == userId).ToListAsync();
            return events is null ? throw new InvalidOperationException($"Cannot find any posted events from user with ID {userId}") : events;
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
				//Category = events.Category,
				Price = events.Price,
				TicketAmount = events.TicketAmount,
				Date = events.Date,
				CreatedAt = DateTime.Now,
				ImageUrl = events.ImageUrl,
			};
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<Event> GetEventWithAdminDetailsAsync(int eventId)
        {
            return await _context.Events.Include(e => e.User).FirstOrDefaultAsync(e => e.Id == eventId);
        }


        public async Task UpdateTicketAmountAsync(int eventId, int newTicketAmount)
        {
            var ev = await _context.Events.FindAsync(eventId);
            if (ev != null)
            {
                ev.TicketAmount = newTicketAmount;
                await _context.SaveChangesAsync();
            }
        }   

		public async Task<IEnumerable<Event>> GetEventByCategoryAsync(Category category)
		{
            return _context.Events.Where(e => e.Category == category);
        }

        public Task<Dictionary<Category, string>> GetCategoryAsync()
        {
            return Task.FromResult(new Dictionary<Category, string>
            {
                { Category.Music, "Music" },
                { Category.Technology, "Technology" },
                { Category.Food_And_Drinks, "Food & Drinks" },
                { Category.Sports, "Sports" },
                { Category.Art_And_Culture, "Art & Culture" },
                { Category.Fashion, "Fashion" },
                { Category.Comedy, "Comedy" },
                { Category.Film, "Film" }
            });
        }
        private string GetDisplayName(Category category)
        {
            return category switch
            {
                Category.Music => "Music",
                Category.Technology => "Technology",
                Category.Food_And_Drinks => "Food & Drinks",
                Category.Sports => "Sports",
                Category.Art_And_Culture => "Art & Culture",
                Category.Fashion => "Fashion",
                Category.Comedy => "Comedy",
                Category.Film => "Film",
                _ => "Unknown"
            };
        }


    }
}

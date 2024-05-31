using ForgeEventApp.Data;
using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using ForgeEventApp.Functions;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Data;

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
            return await _context.Events.Select(e => e).Include(e => e.User).ToListAsync();
        }
        public async Task<IEnumerable<Event>> GetAllEventsPostedByUserAsync(int userId)
        {
            var events = await _context.Events.Where(e => e.User.Id == userId).ToListAsync();
            return events is null ? throw new InvalidOperationException($"Cannot find any posted events from user with ID {userId}") : events;
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
                CreatedAt = DateTime.Now,
                ImageUrl = EventMetricsCalculator.GenerateImg(),
            };
            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();
        }

        public async Task<Event> GetEventWithAdminDetailsAsync(int eventId)
        {
            return await _context.Events.Include(e => e.User).FirstOrDefaultAsync(e => e.Id == eventId);
        }

        public async Task<IEnumerable<Event>> GetEventByCategoryAsync(Category category)
        {
            return await _context.Events.Where(e => e.Category == category).ToListAsync();
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
        public async Task<IEnumerable<Event>> SearchEventAsync(Category category, string searchString)
        {
            IEnumerable<Event> query = await GetAllEventsAsync();

            if (category != (Category)1)
            {
                query = query.Where(e => e.Category == category);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(e => e.Name.Contains(searchString) || e.Description.Contains(searchString));
            }

            return query;
        }

        public async Task<IEnumerable<(Category, string)>> GetCategoryAsync()
        {
            var categories = new List<(Category, string)>
            {
                ((Category)1, "Music"),
                ((Category)2, "Technology"),
                ((Category)3, "Food & Drinks"),
                ((Category)4, "Sports"),
                ((Category)5, "Art & Culture"),
                ((Category)6, "Fashion"),
                ((Category)7, "Comedy"),
                ((Category)8, "Film")
            };

            return await Task.FromResult(categories.AsEnumerable());
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

        public async Task UpdateEventAsync(Event updatedEvent)
        {
            _context.Entry(updatedEvent).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<Event> GetEventFromIdAsync(int eventId)
        {
            var Event = await _context.Events.FirstOrDefaultAsync(e => e.Id == eventId);
            return Event is null ? throw new InvalidOperationException($"Cannot find event with ID {eventId}") : Event;
        }

        public async Task RemoveEventAsync(int eventId)
        {
            var eventToRemove = await GetEventFromIdAsync(eventId);

            if(eventToRemove is not null)
            {
                _context.Events.Remove(eventToRemove);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException($"Cannot find and remove event with ID {eventId}");
            }
        }
    }
}

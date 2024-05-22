﻿using ForgeEventApp.Data;
using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
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

		public async Task<IEnumerable<Event>> GetEventByCategoryAsync(Category category)
		{
            return _context.Events.Where(e => e.Category == category);
        }

        public Task<Dictionary<Category, string>> GetCategoryAsync()
        {
                      
            return Task.FromResult(new Dictionary<Category, string>
            {
                { (Category)1, "Music" },
                { (Category)2, "Technology" },
                { (Category)3, "Food & Drinks" },
                { (Category)4, "Sports" },
                { (Category)5, "Art & Culture" },
                { (Category)6, "Fashion" },
                { (Category)7, "Comedy" },
                { (Category)8, "Film" }
            });

        }
        private string GetDisplayName(Category category)
        {
            return category switch
            {
                Category.Music => "Music",
                Category.Technology => "Technology",
                Category.FoodAndDrinks => "Food & Drinks",  
                Category.Sports => "Sports",
                Category.ArtAndCulture => "Art & Culture",  
                Category.Fashion => "Fashion",
                Category.Comedy => "Comedy",
                Category.Film => "Film",
                _ => "Unknown"
            };
        }


    }
}

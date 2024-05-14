using ForgeEventApp.Data;
using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ForgeEventApp.Repositories
{
	public class RatingRepository : IRatingRepository
	{
		private readonly AppDbContext _context;

		public RatingRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Rating>> GetAllRatingsForEventAsync(int id)
		{
			var ratings = await _context.Ratings.Where(r => r.Event.Id == id).ToListAsync();

			return ratings is null ? throw new InvalidOperationException($"Cannot find ratings for event with ID {id}") : ratings;
		}

	}
}

using ForgeEventApp.Data;
using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ForgeEventApp.Repositories
{
	public class RatingRepository : IRatingRepository
	{
		private readonly AppDbContext _context;
        private readonly IUserRepository _userRepository;
		private readonly IEventRepository _eventRepository;


        public RatingRepository(AppDbContext context, IUserRepository userRepository, IEventRepository eventRepository)
        {
            _context = context;
            _userRepository = userRepository;
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<Rating>> GetAllRatingsForEventAsync(int eventId)
		{
			var ratings = await _context.Ratings.Where(r => r.Event.Id == eventId).Include(r => r.User).ToListAsync();

			return ratings is null ? throw new InvalidOperationException($"Cannot find ratings for event with ID {eventId}") : ratings;
		}

		public async Task AddRatingAsync(Rating rating, int userId, int eventId)
		{
			var user = await _userRepository.GetUserFromIdAsync(userId);
			var ratingEvent = await _eventRepository.GetEventWithAdminDetailsAsync(eventId);
			rating.User = user;
			rating.Event = ratingEvent;
			rating.CreatedAt = DateTime.Now;
			_context.Ratings.Add(rating);
			await _context.SaveChangesAsync();
		}
	}
}

﻿using ForgeEventApp.Data;
using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

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
			var ratingEvent = await _eventRepository.GetEventFromIdAsync(eventId);
			rating.User = user;
			rating.Event = ratingEvent;
			rating.CreatedAt = DateTime.Now;
			_context.Ratings.Add(rating);
			await _context.SaveChangesAsync();
		}

		public async Task<decimal> GetAverageScoreAsync(int eventId)
		{
			decimal score = 0;
			var ratings = await GetAllRatingsForEventAsync(eventId);

			foreach (var rating in ratings)
			{
				score += rating.Score;
			}
			return score / ratings.Count();
		}

        public async Task<IEnumerable<Rating>> GetAllRatingsFromUserForEventAsync(int eventId, int userId)
        {
            var ratings = await _context.Ratings.Where(r => r.Event.Id == eventId && r.User.Id == userId).ToListAsync();
            return ratings is null ? throw new InvalidOperationException($"Cannot find ratings for event with ID {eventId} from user with ID {userId}") : ratings;
        }

        public async Task<Rating> GetRatingFromIdAsync(int ratingId)
        {
			var rating = await _context.Ratings.FirstOrDefaultAsync(r => r.Id == ratingId);
            return rating is null ? throw new InvalidOperationException($"Cannot find rating with ID {ratingId}") : rating;

        }

        public async Task RemoveRatingAsync(int ratingId)
        {
			var rating = await GetRatingFromIdAsync(ratingId);

			if(rating is not null)
			{
				_context.Ratings.Remove(rating);
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new InvalidOperationException($"Cannot find and remove rating with ID {ratingId}");
			}
        }

    }
}

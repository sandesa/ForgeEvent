using ForgeEventApp.Models;

namespace ForgeEventApp.Interfaces
{
	public interface IRatingRepository
	{
		Task<IEnumerable<Rating>> GetAllRatingsForEventAsync(int eventId);
		Task AddRatingAsync(Rating rating, int userId, int eventId);
		Task<decimal> GetAverageScoreAsync(int eventId);
		Task<IEnumerable<Rating>> GetAllRatingsFromUserForEventAsync(int eventId, int userId);
		Task<Rating> GetRatingFromIdAsync(int ratingId);
		Task RemoveRatingAsync(int ratingId);

    }
}

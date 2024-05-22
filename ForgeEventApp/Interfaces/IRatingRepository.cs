using ForgeEventApp.Models;

namespace ForgeEventApp.Interfaces
{
	public interface IRatingRepository
	{
		Task<IEnumerable<Rating>> GetAllRatingsForEventAsync(int eventId);
		Task AddRatingAsync(Rating rating, int userId, int eventId);

    }
}

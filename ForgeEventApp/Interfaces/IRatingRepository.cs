using ForgeEventApp.Models;

namespace ForgeEventApp.Interfaces
{
	public interface IRatingRepository
	{
		Task<IEnumerable<Rating>> GetAllRatingsForEventAsync(int id);
	}
}

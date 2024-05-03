using ForgeEventApp.Models;

namespace ForgeEventApp.Interfaces
{
	public interface IEventRepository
	{
        Task<IEnumerable<Event>> GetAllEventsAsync();

	}
}

using ForgeEventApp.Models;

namespace ForgeEventApp.Interfaces
{
	public interface IEventRepository
	{
        Task<IEnumerable<Event>> GetAllEventsAsync();
		Task<int> GetTicketAmountAsync(int id);
		Task<decimal> GetTicketPriceAsync(int id);
        Task<Event> GetEventByIdAsync(int eventId);
		
    }
}

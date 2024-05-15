using ForgeEventApp.Models;

namespace ForgeEventApp.Interfaces
{
	public interface IEventRepository
	{
		Task<IEnumerable<Event>> GetAllEventsAsync();
		Task<int> GetTicketAmountAsync(int id);
		Task<decimal> GetTicketPriceAsync(int id);
		Task CreateEventAsync(Event events);
		Task<Event> GetEventWithAdminDetailsAsync(int eventId);
        Task<Dictionary<Category, string>> GetCategoryAsync();

        
        //Dictionary<Category, string> CategoryDisplayNames { get; }
    }
}

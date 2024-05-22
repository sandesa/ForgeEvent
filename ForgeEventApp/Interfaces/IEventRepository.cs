using ForgeEventApp.Models;

namespace ForgeEventApp.Interfaces
{
	public interface IEventRepository
	{
		Task<IEnumerable<Event>> GetAllEventsAsync();
		Task<IEnumerable<Event>> GetAllEventsPostedByUserAsync(int userId);
        Task<int> GetTicketAmountAsync(int id);
		Task<decimal> GetTicketPriceAsync(int id);
		Task CreateEventAsync(Event events);
		Task<Event> GetEventWithAdminDetailsAsync(int eventId);
		Task<Event> GetEventFromIdAsync(int eventId);
        Task<IEnumerable<(Category, string)>> GetCategoryAsync();
		Task<IEnumerable<Event>> SearchEventAsync(Category category, string searchString);
		Task UpdateTicketAmountAsync(int eventId, int newTicketAmount);
		Task UpdateEventAsync(Event updatedEvent);
        //Task<Dictionary<Category, string>> GetCategoryAsync();
        //Dictionary<Category, string> CategoryDisplayNames { get; }
    }
}

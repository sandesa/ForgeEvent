using ForgeEventApp.Models;
using System.Threading.Tasks;

namespace ForgeEventApp.Interfaces
{
    public interface ITicketService
    {
        Task<(bool success, string errorMessage)> PurchaseTicketAsync(Event eventDetails, int ticketAmount, int userId);
    }
}

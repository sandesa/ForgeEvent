using ForgeEventApp.Models;
using System.Threading.Tasks;

namespace ForgeEventApp.Interfaces
{
    public interface IBookingService
    {
        Task<bool> AddBookingAsync(Booking booking);
    }
}

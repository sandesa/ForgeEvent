using ForgeEventApp.Models;
using System.Threading.Tasks;

namespace ForgeEventApp.Interfaces
{
    public interface IBookingService
    {
        Task<bool> AddBookingAsync(Booking booking);
        Task<IEnumerable<Booking>> GetAllBookingsByUserIdAsync(int id);
        Task<Booking> GetBookingById(int id);
    }
}

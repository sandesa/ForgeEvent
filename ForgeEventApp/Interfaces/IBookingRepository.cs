using ForgeEventApp.Models;
using System.Threading.Tasks;

namespace ForgeEventApp.Interfaces
{
    public interface IBookingRepository
    {
        Task<bool> AddBookingAsync(Booking booking);
        Task<IEnumerable<Booking>> GetAllBookingsByUserIdAsync(int id);
        Task<Booking> GetBookingByIdAsync(int id);
    }
}

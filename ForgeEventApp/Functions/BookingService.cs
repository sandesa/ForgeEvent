using ForgeEventApp.Data;
using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ForgeEventApp.Services
{
    public class BookingService : IBookingService
    {
        private readonly AppDbContext _context;

        public BookingService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddBookingAsync(Booking booking)
        {
            _context.Entry(booking.User).State = EntityState.Unchanged;
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

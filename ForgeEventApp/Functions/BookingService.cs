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
        public async Task<IEnumerable<Booking>> GetAllBookingsByUserIdAsync(int id)
        {
            var bookings = await _context.Bookings.Where(b => b.User.Id == id)
                                .Include(b => b.Event)
                                .Include(b => b.User)
                                .ToListAsync();
            return bookings;
        }
        public async Task<Booking> GetBookingById(int id)
        {
            var booking = await _context.Bookings.Where(b => b.Id == id)
                                .Include(b => b.Event)
                                .Include(b => b.User)
                                .FirstOrDefaultAsync();

            return booking is null ? throw new InvalidOperationException("Cannot find booking") : booking;

        }
    }
}

using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using ForgeEventApp.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForgeEventApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        public BookingsController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetAllBookingsByUserIdAsync(int id)
        {
            var bookings = await _bookingRepository.GetAllBookingsByUserIdAsync(id);

            if(bookings == null)
            {
                return NotFound();
            }
            return Ok(bookings);
        }

        [HttpGet("booking/{id}")]
        public async Task<ActionResult<Booking>> GetBookingByIdAsync(int id)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(id);

            if (booking == null)
            {
                return NotFound();
            }
            return Ok(booking);
        }

        [HttpPost("{booking}")]
        public async Task<ActionResult<bool>> AddBookingAsync(Booking booking)
        {
            await _bookingRepository.AddBookingAsync(booking);

            return Ok(true);
        }
    }
}

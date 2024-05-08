using ForgeEventApp.Data;
using ForgeEventApp.Interfaces;

namespace ForgeEventApp.Repositories
{
	public class BookingRepository : IBookingRepository
	{
		private readonly AppDbContext _context;

		public BookingRepository(AppDbContext context)
		{
			_context = context;
		}
	}
}

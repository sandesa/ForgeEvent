using ForgeEventApp.Data;
using ForgeEventApp.Interfaces;

namespace ForgeEventApp.Repositories
{
	public class RatingRepository : IRatingRepository 
	{
		private readonly AppDbContext _context;

		public RatingRepository(AppDbContext context)
		{
			_context = context;
		}


	}
}

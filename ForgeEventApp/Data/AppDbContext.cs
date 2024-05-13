using ForgeEventApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ForgeEventApp.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
		public DbSet<Event> Events { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}

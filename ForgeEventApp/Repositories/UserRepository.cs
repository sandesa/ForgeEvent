using ForgeEventApp.Data;
using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForgeEventApp.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly AppDbContext _context;

		public UserRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task CreateUserAsync(User user)
		{
			User newUser = new()
			{
				Role = user.Role,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				PhoneNumber = user.PhoneNumber,
				Password = user.Password,
				Salt = "salt"
			};
			await _context.Users.AddAsync(newUser);
			await _context.SaveChangesAsync();
		}
	}
}

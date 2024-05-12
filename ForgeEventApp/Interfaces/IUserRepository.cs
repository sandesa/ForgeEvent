using ForgeEventApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ForgeEventApp.Interfaces
{
	public interface IUserRepository
	{
		Task CreateUserAsync(User user);
		Task<User> GetUserFromIdAsync(int id);

	}
}

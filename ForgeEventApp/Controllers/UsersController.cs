using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;

namespace ForgeEventApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly IUserRepository _userRepository;

		public UsersController(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}

		[HttpPost]
		public async Task CreateUser(User user)
		{
			await _userRepository.CreateUserAsync(user);
		}
	}
}

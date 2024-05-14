using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using Microsoft.EntityFrameworkCore;
using ForgeEventApp.Repositories;

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

        [HttpGet("{id}")]
        public async Task<User> GetUserById(int id)
        {
            var userDetails = await _userRepository.DisplayProfilePageAsync(id); 

            if (userDetails == null)
            {
               
            }
            return userDetails; 
        }


    }


}






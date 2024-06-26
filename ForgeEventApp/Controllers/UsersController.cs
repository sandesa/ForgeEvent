﻿using Microsoft.AspNetCore.Http;
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

		[HttpPost("{user}")]
        public async Task<ActionResult<User>> CreateUser(User user)
		{
			await _userRepository.CreateUserAsync(user);
			return Ok(user);
		}

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            var userDetails = await _userRepository.GetUserFromIdAsync(id); 

            if (userDetails is null)
            {
				return NotFound();
            }
            return Ok(userDetails); 
        }
        


    }


}






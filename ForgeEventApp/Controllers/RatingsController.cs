using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ForgeEventApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RatingsController : ControllerBase
	{
		private readonly IRatingRepository _ratingRepository;

		public RatingsController(IRatingRepository ratingsRepository)
		{
			_ratingRepository = ratingsRepository;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<IEnumerable<Rating>>> GetAllRatingsForEvent(int id)
		{
			var ratings = await _ratingRepository.GetAllRatingsForEventAsync(id);

			if (ratings is null) 
			{
				return NotFound();
			}
			return Ok(ratings);
		}

	}
}

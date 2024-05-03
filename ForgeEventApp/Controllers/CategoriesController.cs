using Microsoft.AspNetCore.Mvc;
using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;

namespace ForgeEventApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoriesController : ControllerBase
	{
		private readonly ICategoryRepository _categoryRepository;

		public CategoriesController(ICategoryRepository categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		[HttpGet]
		public async Task<ActionResult<Category>>GetAllCategories()
		{
			var categories = await _categoryRepository.GetAllCategoriesAsync();

			if (categories is null)
			{
				return NotFound();
			}
			return Ok(categories);
		}

		[HttpGet("{id:int}")]
		public async Task<ActionResult<Category>> GetCategoryById(int id)
		{
			var categories = await _categoryRepository.GetCategoryByIdAsync(id);

			if (categories is null)
			{
				return NotFound();
			}
			return Ok(categories);
		}

	}
}

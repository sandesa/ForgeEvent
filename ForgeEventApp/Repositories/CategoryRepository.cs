using ForgeEventApp.Data;
using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ForgeEventApp.Repositories
{
    public class CategoryRepository : ICategoryRepository
	{
		private readonly AppDbContext _context;

		public CategoryRepository(AppDbContext context)
		{
			_context = context;
		}
		public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
		{
			return await _context.Categories.Select(c => c).ToListAsync();
		}
		public async Task<Category> GetCategoryByIdAsync(int id)
		{
			var category = await _context.Categories.Where(c => c.Id == id).FirstOrDefaultAsync();

			return category is null ? throw new InvalidOperationException($"Category with ID {id} not found") : category;
		}
	}
}

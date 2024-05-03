using ForgeEventApp.Data;
using ForgeEventApp.Models;

namespace ForgeEventApp.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(int id);

	}
}

using ForgeEventApp.Models;

namespace ForgeEventApp.Data
{
    public class CategorySeedData
    {
        public static async Task InitializeAsync(AppDbContext context)
        {
            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category { Name = "Music" },
                    new Category { Name = "Technology" },
                    new Category { Name = "Food & Drink" },
                    new Category { Name = "Sport" },
                    new Category { Name = "Arts & Culture" },
                    new Category { Name = "Film" },
                    new Category { Name = "Fashion" },
                    new Category { Name = "Comedy" }
                };

                await context.Categories.AddRangeAsync(categories);
                await context.SaveChangesAsync();
            }
        }
    }
}

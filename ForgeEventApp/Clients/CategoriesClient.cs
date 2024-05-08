using ForgeEventApp.Models;

namespace ForgeEventApp.Clients
{
    public class CategoriesClient
    {
        private readonly Category[] categories =
            [
                new()
                {
                    Id = 1,
                    Name = "Music"
                },
                new()
                {
                    Id = 2,
                    Name = "Technology"
                },
                new()
                {
                    Id = 3,
                    Name = "Food & Drinks"
                },
                new()
                {
                    Id = 4,
                    Name = "Sports"
                },
                new()
                {
                    Id = 5,
                    Name = "Art & Culture"
                },
                new()
                {
                    Id = 6,
                    Name = "Fashion"
                },
                new()
                {
                    Id = 7,
                    Name = "Comedy"
                },
            ];
        public Category[] GetCategories => categories;
    }
}

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
                    Name = "Test1"
                },
                new()
                {
                    Id = 2,
                    Name = "Test2"
                },
                new()
                {
                    Id = 3,
                    Name = "Test3"
                },
                new()
                {
                    Id = 4,
                    Name = "Test4"
                },
                new()
                {
                    Id = 5,
                    Name = "Test5"
                },
                new()
                {
                    Id = 6,
                    Name = "Test6"
                },
            ];
        public Category[] GetCategories => categories;
    }
}

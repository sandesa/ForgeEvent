using ForgeEventApp.Models;

namespace ForgeEventApp.Data
{
    public class UserData
    {
        public static async Task InitializeAsync(AppDbContext context)
        {
            if (!context.Users.Any())
            {
                var users = new List<User>
                {
                    new()
                    {
                        Role = Role.Admin,
                        FirstName = "John",
                        LastName = "Doe",
                        Email = "john.doe@example.com",
                        PhoneNumber = "123-456-7890",
                        Password = "hashed_password",
                        Salt = "random_salt"
                    },
                    new User
                    {
                        Role = Role.Account,
                        FirstName = "Jane",
                        LastName = "Smith",
                        Email = "jane.smith@example.com",
                        PhoneNumber = "987-654-3210",
                        Password = "hashed_password",
                        Salt = "random_salt"
                    },
                    new User
                    {
                        Role = Role.Admin,
                        FirstName = "Ryan",
                        LastName = "Reynolds",
                        Email = "Ryan.Reynolds@example.com",
                        PhoneNumber = "524-124-4334",
                        Password = "hashed_password",
                        Salt = "random_salt"
                    }
                };
                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();
            }
        }
    }
}

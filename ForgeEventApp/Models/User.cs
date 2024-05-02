using System.ComponentModel.DataAnnotations;

namespace ForgeEventApp.Models
{
    public enum Role
    {
        User = 0,
        Admin = 1
    }

    public class User
    {
        public int Id { get; set; }
        public required Role Role { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public string? PhoneNumber { get; set; }
        public required string Password { get; set; }
        public string? Salt { get; set; }
    }
}

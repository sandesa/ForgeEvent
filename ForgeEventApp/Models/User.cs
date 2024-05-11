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

        [Required(ErrorMessage = "Error R")]
        public Role Role { get; set; }

        [Required(ErrorMessage = "Required first name")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Required last name")]
		public required string LastName { get; set; }

        [Required(ErrorMessage = "Required email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Required phonenumber")]
		public required string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Required password")]
		public required string Password { get; set; }

        [Required(ErrorMessage = "Error S")]
		public required string Salt { get; set; }
    }
}
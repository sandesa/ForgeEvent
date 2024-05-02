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
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Required last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Required email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Required phonenumber")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Required password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Error S")]
        public string Salt { get; set; }
    }
}
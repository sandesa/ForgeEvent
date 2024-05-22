using System.ComponentModel.DataAnnotations;

namespace ForgeEventApp.Models
{
	public class Rating
	{
        public int Id { get; set; }

        [Range(1, 5, ErrorMessage = "Score must be between 1 and 5.")]
        public int Score { get; set; }

        [StringLength(500, ErrorMessage = "Comment cannot exceed 500 characters.")]
        public string? Comment { get; set; }

        public DateTime CreatedAt { get; set; }

        public Event Event { get; set; }

		//[Required(ErrorMessage = "required must be signed in to rate")]
		public User User { get; set; }
    }
}

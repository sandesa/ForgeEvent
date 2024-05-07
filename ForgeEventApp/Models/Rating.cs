using System.ComponentModel.DataAnnotations;

namespace ForgeEventApp.Models
{
	public class Rating
	{
        public int Id { get; set; }

        [Required(ErrorMessage = "required score")]
        public int Score { get; set; }

        public string? Comment { get; set; }

        public required Event Event { get; set; }

		[Required(ErrorMessage = "required must be signed in to rate")]
		public required User User { get; set; }
    }
}

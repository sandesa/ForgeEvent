using System.ComponentModel.DataAnnotations;

namespace ForgeEventApp.Models
{
	public class Booking
	{
        public int Id { get; set; }
        [Range(1, 100, ErrorMessage = "At least one ticket")]
        public int TicketAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt  { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
    }
}

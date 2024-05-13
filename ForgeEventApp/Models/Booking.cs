namespace ForgeEventApp.Models
{
	public class Booking
	{
        public int Id { get; set; }
        public int TicketAmount { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt  { get; set; }
        public User User { get; set; }
        public Event Event { get; set; }
    }
}

namespace ForgeEventApp.Models
{
	public class Booking
	{
        public int Id { get; set; }
        public required int TicketAmount { get; set; }
        public required decimal TotalPrice { get; set; }
        public required DateTime CreatedAt  { get; set; }
        public required User User { get; set; }
        public required Event Event { get; set; }
    }
}

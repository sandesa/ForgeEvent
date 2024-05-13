using ForgeEventApp.Functions;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.ComponentModel.DataAnnotations;


namespace ForgeEventApp.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Event must have a name")]
		public string Name { get; set; }

        public string? ImageUrl { get; set; }

        [Range(100, 99999,ErrorMessage = "Ticket amount must be at least 100 tickets")]
        public int TicketAmount { get; set; }

        [Required(ErrorMessage = "Event must have a Adress")]
        public string Address { get; set;}

        [ValidateSetDates(ErrorMessage = "The date must be at least 30 days ahead of today's date.")]
        public DateTime Date { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "Event must have a description")]
        public string Description { get; set;}

        [Range(1, 9999, ErrorMessage = "Ticket price must be at least 1")]
        public decimal Price { get; set; }

		//[Required(ErrorMessage = "required event category")] 
		public string? Category { get; set; }

		//[Required(ErrorMessage = "euerror")]
		public User? User { get; set; }
	}
}

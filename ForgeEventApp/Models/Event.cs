using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.ComponentModel.DataAnnotations;


namespace ForgeEventApp.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="required eventname")]
		public string Name { get; set; }

        public string? ImageUrl { get; set; }

        [Required(ErrorMessage = "required ticket amount")]
        public int TicketAmount { get; set; }

        [Required(ErrorMessage = "required address")]
        public string Address { get; set;}

        [Required(ErrorMessage = "required event date time")]
        public DateTime Date { get; set; }

        public DateTime CreatedAt { get; set; }

        [Required(ErrorMessage = "required description")]
        public string Description { get; set;}

        [Required(ErrorMessage = "required ticket price")]
        public decimal Price { get; set; }

    }
}

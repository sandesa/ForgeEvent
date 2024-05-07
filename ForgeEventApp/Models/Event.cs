using Microsoft.AspNetCore.Mvc.Diagnostics;
using System.ComponentModel.DataAnnotations;


namespace ForgeEventApp.Models
{
    public class Event
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="required eventname")]
		public required string Name { get; set; }
        public string? ImageUrl { get; set; }
        [Required(ErrorMessage = "required ticket amount")]
        public int TicketAmount { get; set; }
        [Required(ErrorMessage = "required address")]
        public required string Address { get; set;}
        [Required(ErrorMessage = "required event date time")]
        public DateOnly Date { get; set; }
        public DateOnly CreatedAt { get; set; }
        [Required(ErrorMessage = "required description")]
        public required string Description { get; set;}
        [Required(ErrorMessage = "required ticket price")]
        public decimal Price { get; set; }
        //[Required(ErrorMessage = "required event category")] 
        public string? Category { get; set; }

        //[Required(ErrorMessage = "euerror")]
        public User? User { get; set; }
    }
}

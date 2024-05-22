
using ForgeEventApp.Clients;
using ForgeEventApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace ForgeEventApp.Data
{
	public class EventSeedData
	{
		public static async Task InitializeAsync(AppDbContext context)
		{
			if (!context.Events.Any())
			{						
				await UserData.InitializeAsync(context);
				var users = await context.Users.ToListAsync();

				var events = new List<Event>
				{
					new()
					{
						Name = "Music Festival",
						ImageUrl = "MusicFestival.jpg",
						TicketAmount = 500,
						Address = "123 Main Street, Cityville",
						Date = new DateTime(2024,06,15),
						CreatedAt = new DateTime(2024,05,01),
						Description = "Join us for a day of live music, food, and fun!",
						Price = 25.00m,
                        Category = Category.Music,
                        User = users.FirstOrDefault(u => u.Id == 1)
					},
					new()
					{
						Name = "Tech Conference",
						ImageUrl = "Tech-News.jpg",
						TicketAmount = 300,
						Address = "456 Tech Boulevard, Techland",
						Date = new DateTime(2024,07,20),
						CreatedAt = new DateTime(2024,05,02),
						Description = "Explore the latest trends and innovations in technology.",
						Price = 50.00m,
                        Category = Category.Technology,
                        User = users.FirstOrDefault(u => u.Id == 1)
					},
					new()
					{
						Name = "Food Expo",
						ImageUrl = "Food-Market.jpg",
						TicketAmount = 200,
						Address = "789 Culinary Avenue, Foodtown",
						Date = new DateTime(2024,08,10),
						CreatedAt = new DateTime(2024, 05, 03),
						Description = "Experience a variety of cuisines from around the world.",
						Price = 20.00m,
                        Category = Category.Food_And_Drinks,
                        User = users.FirstOrDefault(u => u.Id == 1)
					},
					new()
					{
						Name = "Sports Tournament",
						ImageUrl = "rangers-1402096_1280.jpg",
						TicketAmount = 1000,
						Address = "101 Stadium Way, Sportscity",
						Date = new DateTime(2024, 09, 05),
						CreatedAt = new DateTime(2024, 05, 04),
						Description = "Compete or cheer on your favorite teams in various sports.",
						Price = 10.00m,
                        Category = Category.Sports,
                        User = users.FirstOrDefault(u => u.Id == 3)
					},
					new()
					{
						Name = "Art Exhibition",
						ImageUrl = "Art-Exhibition.jpg",
						TicketAmount = 400,
						Address = "222 Gallery Street, Artville",
						Date = new DateTime(2024,10,15),
						CreatedAt = new DateTime(2024, 05, 05),
						Description = "Marvel at the creativity and talent of local artists.",
						Price = 15.00m,
						Category = Category.Art_And_Culture,
						User = users.FirstOrDefault(u => u.Id == 3)
					},
					new()
					{
						Name = "Fitness Bootcamp",
						ImageUrl = "Fitness-Bootcamp.jpg",
						TicketAmount = 100,
						Address = "123 Fit Street, Healthville",
						Date = new DateTime(2024, 11, 25),
						CreatedAt = new DateTime(2024, 05, 06),
						Description = "Join us for an intense workout session led by professional trainers. Suitable for all fitness levels.",
						Price = 15.00m,
						Category = Category.Sports,
						User = users.FirstOrDefault(u => u.Id == 3)
					},
					new()
					{
						Name = "Film Festival",
						ImageUrl = "Film-Festival.jpg",
						TicketAmount = 600,
						Address = "444 Cinema Lane, Movietown",
						Date = new DateTime(2024, 12, 10),
						CreatedAt = new DateTime(2024, 05, 07),
						Description = "Discover new films and meet filmmakers from around the world.",
						Price = 30.00m,
						Category = Category.Film,
						User = users.FirstOrDefault(u => u.Id == 1)
					},
					new()
					{
						Name = "Fashion Show",
						ImageUrl = "fashion-show-1746590_1280.jpg",
						TicketAmount = 250,
						Address = "555 Runway Avenue, Fashionville",
						Date = new DateTime(2025, 01, 25),
						CreatedAt = new DateTime(2024, 05, 08),
						Description = "Witness the latest trends and designs on the runway.",
						Price = 40.00m,
						Category = Category.Fashion,
						User = users.FirstOrDefault(u => u.Id == 1)
					},
					new()
					{
						Name = "Science Fair",
						ImageUrl = "Science-Fair.jpg",
						TicketAmount = 300,
						Address = "666 Discovery Drive, Sciencetown",
						Date = new DateTime(2025, 02, 15),
						CreatedAt = new DateTime(2024, 05, 09),
						Description = "Explore fascinating experiments and innovations in science.",
						Price = 10.00m,
						Category = Category.Technology,
						User = users.FirstOrDefault(u => u.Id == 3)
					},
					new()
					{
						Name = "Comedy Show",
						ImageUrl = "comedian-2125295_1280.jpg",
						TicketAmount = 200,
						Address = "777 Laughter Lane, Comedyville",
						Date = new DateTime(2025, 03, 10),
						CreatedAt = new DateTime(2024, 05, 10),
						Description = "Laugh the night away with hilarious stand-up performances.",
						Price = 20.00m,
						Category = Category.Comedy,
						User = users.FirstOrDefault(u => u.Id == 1)

					}
				};
				await context.Events.AddRangeAsync(events);
				await context.SaveChangesAsync();
			}
		}
	}
}

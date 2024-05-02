using ForgeEventApp.Models;
using System;

namespace ForgeEventApp.Data
{
    public class EventSeedData
    {
        public static async Task InitializeAsync(AppDbContext context)
        {
            if (!context.Events.Any())
            {
                var events = new List<Event>
                {
                    new()
                    {
                        Name = "Music Festival",
                        ImageUrl = "MusicFestival.jpg",
                        TicketAmount = 500,
                        Address = "123 Main Street, Cityville",
                        EventDate = 2024 - 06 - 15,
                        CreatedAt = 2024 - 05 - 01,
                        Description = "Join us for a day of live music, food, and fun!",
                        Price = 25.00m,
                        Category = "Music",
                        User = "Admin"
                    },
                    new()
                    {
                        Name = "Tech Conference",
                        ImageUrl = "Tech-News.jpg",
                        TicketAmount = 300,
                        Address = "456 Tech Boulevard, Techland",
                        EventDate = 2024-07-20,
                        CreatedAt = 2024-05-02,
                        Description = "Explore the latest trends and innovations in technology.",
                        Price = 50.00m,
                        Category = "Technology",
                        User = "Admin"
                    }, 
                    new() 
                    {
                        Name = "Food Expo",
                        ImageUrl = "Food-Market.jpg",
                        TicketAmount = 200,
                        Address = "789 Culinary Avenue, Foodtown",
                        EventDate = 2024-08-10,
                        CreatedAt = 2024-05-03,
                        Description = "Experience a variety of cuisines from around the world.",
                        Price = 20.00m,
                        Category = "Food & Drink",
                        User = "Admin"
                    },
                    new()
                    {
                        Name = "Sports Tournament",
                        ImageUrl = "rangers-1402096_1280.jpg",
                        TicketAmount = 1000,
                        Address = "101 Stadium Way, Sportscity",
                        EventDate = 2024-09-05,
                        CreatedAt = 2024-05-04,
                        Description = "Compete or cheer on your favorite teams in various sports.",
                        Price = 10.00m,
                        Category = "Sports",
                        User = "Admin"
                    },
                    new()
                    {
                        Name = "Art Exhibition",
                        ImageUrl = "Art-Exhibition.jpg",
                        TicketAmount = 400,
                        Address = "222 Gallery Street, Artville",
                        EventDate = 2024-10-15,
                        CreatedAt = 2024-05-05,
                        Description = "Marvel at the creativity and talent of local artists.",
                        Price = 15.00m,
                        Category = "Arts & Culture",
                        User = "Admin"
                    }, 
                    new() 
                    {
                        Name = "Fitness Bootcamp",
                        ImageUrl = "Fitness-Bootcamp.jpg",
                        TicketAmount = 100,
                        Address = "123 Fit Street, Healthville",
                        EventDate = 2024-11-25,
                        CreatedAt = 2024-05-06,
                        Description = "Join us for an intense workout session led by professional trainers. Suitable for all fitness levels.",
                        Price = 15.00m,
                        Category = "Sports & Fitness",
                        User = "Admin"
                    },
                    new()
                    {
                        Name = "Film Festival",
                        ImageUrl = "Film-Festival.jpg",
                        TicketAmount = 600,
                        Address = "444 Cinema Lane, Movietown",
                        EventDate = 2024-12-10,
                        CreatedAt = 2024-05-07,
                        Description = "Discover new films and meet filmmakers from around the world.",
                        Price = 30.00m,
                        Category = "Film & Media",
                        User = "Admin"
                    },
                    new()
                    {
                        Name = "Fashion Show",
                        ImageUrl = "fashion-show-1746590_1280.jpg",
                        TicketAmount = 250,
                        Address = "555 Runway Avenue, Fashionville",
                        EventDate = 2025-01-25,
                        CreatedAt = 2024-05-08,
                        Description = "Witness the latest trends and designs on the runway.",
                        Price = 40.00m,
                        Category = "Fashion & Beauty",
                        User = "Admin"
                    },
                    new()
                    {
                        Name = "Science Fair",
                        ImageUrl = "Science-Fair.jpg",
                        TicketAmount = 300,
                        Address = "666 Discovery Drive, Sciencetown",
                        EventDate = 2025-02-15,
                        CreatedAt = 2024-05-09,
                        Description = "Explore fascinating experiments and innovations in science.",
                        Price = 10.00m,
                        Category = "Science & Technology",
                        User = "Admin"
                    },
                    new() 
                    {
                        Name = "Comedy Show",
                        ImageUrl = "comedian-2125295_1280.jpg",
                        TicketAmount = 200,
                        Address = "777 Laughter Lane, Comedyville",
                        EventDate = 2025-03-10,
                        CreatedAt = 2024-05-10,
                        Description = "Laugh the night away with hilarious stand-up performances.",
                        Price = 20.00m,
                        Category = "Comedy",
                        User = "Admin"
                    }
                };
                await context.Events.AddRangeAsync(events);
                await context.SaveChangesAsync();
    }
}
    }
}

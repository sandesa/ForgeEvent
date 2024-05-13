using ForgeEventApp.Interfaces;
using ForgeEventApp.Repositories;
using Microsoft.OpenApi.Models;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography;

namespace ForgeEventApp.Functions
{
    public class EventMetricsCalculator
    {
        private readonly IEventRepository _eventRepository;

        public EventMetricsCalculator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            byte[] hashedPasswordBytes = Convert.FromBase64String(hashedPassword);
            byte[] saltBytes = new byte[16];
            Array.Copy(hashedPasswordBytes, 0, saltBytes, 0, 16);

            using (var pbkdf2 = new Rfc2898DeriveBytes(password, saltBytes, 10000))
            {
                byte[] hash = pbkdf2.GetBytes(20);

                for (int i = 0; i < 20; i++)
                {
                    if (hashedPasswordBytes[i + 16] != hash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public async Task<int> TicketAmountPurchase(int ticketPurchase)
        {
            int total = 0;

            int ticketAmount = await _eventRepository.GetTicketAmountAsync(1);

            if (ticketPurchase > ticketAmount)
            {
                return total;
            }

            return total;
        }

        public async Task<decimal> TicketTotalPrice(int ticketPurchaseAmount)
        {
            decimal total = 0;

            decimal ticketPrice = await _eventRepository.GetTicketPriceAsync(1);

            total = ticketPrice * ticketPurchaseAmount;

            return total;
        }

        public int RatingCalculator()
        {
            int rating = 0;

            // rating model

            return rating;
        }

        public double AverageRating()
        {
            double total = 0;

            return total;
        }
    }
}

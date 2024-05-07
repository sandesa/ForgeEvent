using ForgeEventApp.Interfaces;
using ForgeEventApp.Repositories;
using Microsoft.OpenApi.Models;
using System.Reflection.Metadata.Ecma335;

namespace ForgeEventApp.Functions
{
    public class EventMetricsCalculator
    {
        private readonly IEventRepository _eventRepository;

        public EventMetricsCalculator(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
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

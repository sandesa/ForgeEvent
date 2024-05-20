using ForgeEventApp.Interfaces;
using ForgeEventApp.Models;
using ForgeEventApp.Repositories;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace ForgeEventApp.Services
{
    public class TicketService : ITicketService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IBookingService _bookingService;
        private readonly IUserRepository _userRepository;
        private readonly NavigationManager _navigationManager;

        public TicketService(IEventRepository eventRepository, IBookingService bookingService, NavigationManager navigationManager, IUserRepository userRepository)
        {
            _eventRepository = eventRepository;
            _bookingService = bookingService;
            _navigationManager = navigationManager;
            _userRepository = userRepository;
        }

        public async Task<(bool success, string errorMessage)> PurchaseTicketAsync(Event eventDetails, int ticketAmount, int userId)
        {
            if (ticketAmount <= 0)
            {
                return (false, "Invalid ticket amount.");
            }

            int ticketAmountLeft = await _eventRepository.GetTicketAmountAsync(eventDetails.Id);
            if (ticketAmount > ticketAmountLeft)
            {
                return (false, "Not enough tickets available.");
            }

            try
            {
                int newTicketAmount = eventDetails.TicketAmount - ticketAmount;
                await _eventRepository.UpdateTicketAmountAsync(eventDetails.Id, newTicketAmount);

                var user = await _userRepository.GetUserFromIdAsync(userId);

                var booking = new Booking
                {
                    TicketAmount = ticketAmount,
                    TotalPrice = ticketAmount * eventDetails.Price,
                    CreatedAt = DateTime.Now,
                    User = user,
                    Event = eventDetails
                };

                bool bookingSuccess = await _bookingService.AddBookingAsync(booking);
                if (!bookingSuccess)
                {
                    return (false, "Failed to create booking.");
                }

                _navigationManager.NavigateTo($"/ticketpurchaseconfirmation/{eventDetails.Id}/{ticketAmount}");
                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, $"An error occurred: {ex.Message}");
            }
        }
    }
}

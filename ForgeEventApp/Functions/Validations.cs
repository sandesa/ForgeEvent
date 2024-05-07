using ForgeEventApp.Interfaces;

namespace ForgeEventApp.Functions
{
    public class Validations
    {
        private readonly IEventRepository _eventRepository;

        public Validations(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }
        public async Task<bool> ValidateTicketAmount(int ticketAmount)
        {
            int amount = ticketAmount;

            if (amount <= 0)
            {
                return false;
            }

            return true;
        }

        public async Task<bool> ValidateTicketAmountLeft(int ticketAmount, int id)
        {
            int amount = ticketAmount;
            int eventId = id;
            int ticketAmountLeft = await _eventRepository.GetTicketAmountAsync(eventId);

            if (ticketAmountLeft > amount)
            {
                return false;
            }

            return true;
        }
    }
}

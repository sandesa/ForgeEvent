using ForgeEventApp.Interfaces;
using System.Security.Cryptography;

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
    }
}

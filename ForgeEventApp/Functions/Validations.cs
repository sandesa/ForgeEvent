namespace ForgeEventApp.Functions
{
    public class Validations
    {
        public static bool ValidateTicketAmount(int ticketAmount)
        {
            if (ticketAmount <= 0)
            {
                return false;
            }

            return true;
        }
    }
}

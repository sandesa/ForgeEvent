
namespace ForgeEventApp.Interfaces;

public interface IValidations
{
   Task<bool> SubmitFormAsync(Action formSubmit);
   Task RestValidFormBool();
   Task<bool> ValidateTicketAmountLeft(int ticketAmount, int id);
   string DisplayCategory(object category);
}

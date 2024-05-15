using System.ComponentModel.DataAnnotations;

namespace ForgeEventApp.Functions
{
    public class ValidateSetDates : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime date && date.Date < DateTime.Now.AddDays(30).Date)
            {
                return new ValidationResult(ErrorMessage ?? "The date must be at least 30 days ahead of today's date.");
            }

            return ValidationResult.Success;
        }
    }
}

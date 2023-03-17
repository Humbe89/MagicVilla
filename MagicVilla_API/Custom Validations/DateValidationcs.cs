using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Custom_Validations
{
    public class DateValidationcs: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            DateTime dateOfBirth = Convert.ToDateTime(value);
            if (dateOfBirth == null) {
                return new ValidationResult("The Date of Birth cannot be null");
            }
            if (dateOfBirth > DateTime.Now) {
                return new ValidationResult("The Date of Birth cannot be in the future");
            }

            return ValidationResult.Success;

            //return base.IsValid(value, validationContext);
        }
    }
}

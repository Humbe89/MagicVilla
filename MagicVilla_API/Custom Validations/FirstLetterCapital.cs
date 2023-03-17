using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Custom_Validations
{
    public class FirstLetterCapital: ValidationAttribute
    {
        protected override ValidationResult? IsValid(object value, ValidationContext validationContext)
        {
            if (string.IsNullOrEmpty(value.ToString())) {
                return new ValidationResult("This field cannot be null I am into Custom Validation");
            }

            if ( !char.IsUpper(value.ToString()[0])) {
                return new ValidationResult("The first letter has be Capital");
            }

            return ValidationResult.Success;
            
            //return base.IsValid(value, validationContext);
        }
    }
}

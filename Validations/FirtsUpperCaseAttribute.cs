using BooksAPI.Entitites;
using System.ComponentModel.DataAnnotations;

namespace BooksAPI.Validations
{
    public class FirtsUpperCaseAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var firstLatter = value.ToString()[0].ToString();

            if (firstLatter != firstLatter.ToUpper())
            {
                return new ValidationResult("First letter must be Uppercase");
            }

            return ValidationResult.Success;
        }
    }
}

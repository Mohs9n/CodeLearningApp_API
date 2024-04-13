using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using codegym_api.Dtos;

namespace codegym_api.Entities.Validations;

public class UserEmailIsEmail : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var user = validationContext.ObjectInstance as RegisterDto;
        Console.WriteLine("Hello outside!");
        if (user != null)
        {
          Console.WriteLine("Hello Inside!");
          if (user.Email is not null && IsEmail(user.Email))
          {
            Console.WriteLine("Hello In If!");
            return ValidationResult.Success;
          }
        }
        return new ValidationResult("User Email must be in a valid email format");
    }

    private static bool IsEmail(string email)
    {
      if (string.IsNullOrWhiteSpace(email))
      {
        return false;
      }

      const string emailRegex = @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$";
      return Regex.IsMatch(email, emailRegex);
    }
}

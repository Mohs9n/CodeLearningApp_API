using System.ComponentModel.DataAnnotations;
using codegym_api.Entities.Validations;

namespace codegym_api.Dtos;

public class RegisterDto
{
    // [EmailAddress]

    [UserEmailIsEmail]
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

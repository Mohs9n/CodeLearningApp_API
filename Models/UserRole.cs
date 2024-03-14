using Microsoft.AspNetCore.Identity;

namespace codegym_api.Models;

public class UserRole : IdentityUserRole<int>
{
    public required User User { get; set; }
    public required AppRole Role { get; set; }
}

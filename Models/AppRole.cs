using Microsoft.AspNetCore.Identity;

namespace codegym_api.Models;

public class AppRole : IdentityRole<int>
{
    public required ICollection<UserRole> UserRoles { get; set; }
}

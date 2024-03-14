using Microsoft.AspNetCore.Identity;

namespace codegym_api.Models;

public class User : IdentityUser
{
  public required string FName { get; set; }
  public required string LName { get; set; }
  public required string Type { get; set; }
  public int Streak { get; set; }
  public int Score { get; set; }
  public required List<DateOnly> LoginDays { get; set; }   

  public required ICollection<UserRole> UserRoles { get; set; }
}

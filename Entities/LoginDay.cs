namespace codegym_api.Entities;

public class LoginDay
{
    public int Id { get; set; }
    public DateOnly Day { get; set; }
    public string UserId { get; set; }
    // public User User { get; set; }
}

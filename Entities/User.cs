using Microsoft.AspNetCore.Identity;

namespace codegym_api.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Type { get; set; } // Admin, Noraml User
    public int Streak { get; set; }
    public int Score { get; set; }
    public List<LoginDay> LoginDays { get; set; } = [];
    public List<DoneArticle> DoneArticles { get; set; } = [];

    // public User(string fName, string lName, string type)
    // {
    //     FName = fName;
    //     LName = lName;
    //     Type = type;
    // }
}

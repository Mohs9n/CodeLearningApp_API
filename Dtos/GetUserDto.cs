using codegym_api.Entities;

namespace codegym_api.Dtos;

public class GetUserDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Streak { get; set; }
    public int Score { get; set; }
    public List<LoginDay> LoginDays { get; set; } = [];
    public List<DoneArticle> DoneArticles { get; set; } = [];
}

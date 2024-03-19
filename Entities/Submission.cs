namespace codegym_api.Entities;

public class Submission
{
  public int Id { get; set; }
  public int ArticleId { get; set; }
  public string UserId { get; set; }
  public string Code { get; set; }
  public string Output { get; set; }
  public string Status { get; set; }
}

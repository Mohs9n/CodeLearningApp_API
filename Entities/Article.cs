namespace codegym_api.Entities;

public class Article
{
  public int Id { get; set; }
  public required string Title { get; set; }
  public required string Type { get; set; }
  public required int Score { get; set; }
  public required string Content { get; set; }
  public required string Solution { get; set; }
  public required string Category { get; set; }
}

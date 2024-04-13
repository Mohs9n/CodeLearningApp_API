using System.ComponentModel.DataAnnotations;

namespace codegym_api.Entities;

public class Article
{
  public int Id { get; set; }
  [Required]
  public required string Title { get; set; }
  [Required]
  public required string Type { get; set; }
  public required int Score { get; set; }
  public required string Content { get; set; }
  public required string Solution { get; set; }
  public required string Category { get; set; }
}

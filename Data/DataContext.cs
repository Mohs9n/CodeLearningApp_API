using codegym_api.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace codegym_api.Data;

public class DataContext : IdentityDbContext<User>
{
    public DataContext(DbContextOptions options) : base(options)
    {
    }
    public DbSet<Article> Articles { get; set; }
    public DbSet<LoginDay> LoginDays { get; set; }
    public DbSet<DoneArticle> DoneArticles { get; set; }
    public DbSet<Submission> Submissions { get; set; }
}

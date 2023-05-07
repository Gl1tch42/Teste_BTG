using Microsoft.EntityFrameworkCore;

namespace Api.Models;

public class MyContext : DbContext
{
    public MyContext(DbContextOptions<MyContext> options)
        : base(options)
    {
    }

    public DbSet<GitRepository> GitRepositories { get; set; } = null!;
    public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; } = null!;
    public DbSet<GitRepositoryOwner> GitRepositoryOwner { get; set; } = null!;
    
}
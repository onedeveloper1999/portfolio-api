using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities;

namespace Portfolio.Infrastructure.Persistence;
public class PortfolioContext : DbContextBase
{
    public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options) { }
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Skill> Skills { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<ContactMessage> ContactMessages { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("portfolio");
    }
}

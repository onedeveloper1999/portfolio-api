using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Portfolio.Core.Entities;

namespace Portfolio.Infrastructure.Persistence;
public class PortfolioContext : DbContext
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

    public Task<int> SaveChangesAsync(int currentUserId, CancellationToken cancellationToken = default)
    {
        DateTimeOffset saveTime = DateTimeOffset.Now;
        IEnumerable<EntityEntry> entries = ChangeTracker.Entries();
        if (entries.Any())
        {
            foreach (EntityEntry entry in entries.Where(x => x.State is EntityState.Added or EntityState.Modified))
            {
                if (entry.Entity is BaseEntity dataEntity)
                {
                    if (entry.State == EntityState.Added)
                    {
                        dataEntity.CreatedOn = dataEntity.CreatedOn == default ? saveTime : dataEntity.CreatedOn;
                        dataEntity.CreatedByUserId = dataEntity.CreatedByUserId == default ? currentUserId : dataEntity.CreatedByUserId;
                    }
                    dataEntity.LastUpdatedOn = saveTime;
                    dataEntity.LastUpdatedByUserId = currentUserId;
                }
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}

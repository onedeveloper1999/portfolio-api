using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Portfolio.Core.Entities;

namespace Portfolio.Infrastructure.Persistence;
public class DbContextBase : DbContext
{
    public DbContextBase(DbContextOptions options) : base(options) { }

    /// <summary> Asynchronously saves all changes made in this context to the database. </summary>
    /// <param name="currentUserId"></param>
    /// <param name="cancellationToken"> 
    /// A System.Threading.CancellationToken to observe while waiting for the task to complete.
    /// </param>
    /// <returns>
    /// A task that represents the asynchronous save operation. The task result contains 
    /// the number of state entries written to the database.
    /// </returns>
    /// <remarks>
    /// This method will automatically call Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.DetectChanges
    /// to discover any changes to entity instances before saving to the underlying database.
    /// This can be disabled via Microsoft.EntityFrameworkCore.ChangeTracking.ChangeTracker.AutoDetectChangesEnabled.
    /// Multiple active operations on the same context instance are not supported. Use
    /// 'await' to ensure that any asynchronous operations have completed before calling
    /// another method on this context.
    /// </remarks>
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

    public Task<int> ExecuteUpdateAsync(int currentUserId, CancellationToken cancellationToken = default)
    {
        DateTimeOffset saveTime = DateTimeOffset.Now;
        IEnumerable<EntityEntry> entries = ChangeTracker.Entries();
        if (entries.Any())
        {
            foreach (EntityEntry entry in entries.Where(x => x.State is EntityState.Modified))
            {
                if (entry.Entity is BaseEntity dataEntity)
                {
                    dataEntity.LastUpdatedOn = saveTime;
                    dataEntity.LastUpdatedByUserId = currentUserId;
                }
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }

}

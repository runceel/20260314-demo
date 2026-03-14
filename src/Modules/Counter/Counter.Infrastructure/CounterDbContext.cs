using Counter.Application;
using Counter.Domain;
using Microsoft.EntityFrameworkCore;

namespace Counter.Infrastructure;

public class CounterDbContext(DbContextOptions<CounterDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<CounterEntity> Counters => Set<CounterEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CounterEntity>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.HasData(new CounterEntity { ID = 1, CurrentCount = 0 });
        });
    }
}

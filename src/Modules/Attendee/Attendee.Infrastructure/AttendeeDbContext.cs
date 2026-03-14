using Attendee.Application;
using Attendee.Domain;
using Microsoft.EntityFrameworkCore;

namespace Attendee.Infrastructure;

public class AttendeeDbContext(DbContextOptions<AttendeeDbContext> options) : DbContext(options), IUnitOfWork
{
    public DbSet<AttendeeEntity> Attendees => Set<AttendeeEntity>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AttendeeEntity>(entity =>
        {
            entity.HasKey(e => e.ID);
            entity.Property(e => e.AccountName).IsRequired();

            entity.HasData(
                new AttendeeEntity { ID = 1, AccountName = "tanaka_taro", IsAttended = false },
                new AttendeeEntity { ID = 2, AccountName = "suzuki_hanako", IsAttended = false },
                new AttendeeEntity { ID = 3, AccountName = "yamamoto_koji", IsAttended = false },
                new AttendeeEntity { ID = 4, AccountName = "watanabe_yuki", IsAttended = false },
                new AttendeeEntity { ID = 5, AccountName = "ito_sakura", IsAttended = false },
                new AttendeeEntity { ID = 6, AccountName = "takahashi_ken", IsAttended = false },
                new AttendeeEntity { ID = 7, AccountName = "kobayashi_mana", IsAttended = false },
                new AttendeeEntity { ID = 8, AccountName = "nakamura_ryo", IsAttended = false },
                new AttendeeEntity { ID = 9, AccountName = "saito_akira", IsAttended = false },
                new AttendeeEntity { ID = 10, AccountName = "kato_megumi", IsAttended = false }
            );
        });
    }
}

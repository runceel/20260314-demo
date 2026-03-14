using Attendee.Domain;
using Microsoft.EntityFrameworkCore;

namespace Attendee.Infrastructure;

public class AttendeeRepository(AttendeeDbContext dbContext) : Application.IAttendeeRepository
{
    public async Task<IReadOnlyList<AttendeeEntity>> GetAllAsync()
    {
        return await dbContext.Attendees.ToListAsync();
    }

    public async Task<AttendeeEntity?> GetAsync(int id)
    {
        return await dbContext.Attendees.FindAsync(id);
    }

    public async Task UpdateAttendanceAsync(int id, bool isAttended)
    {
        var entity = await dbContext.Attendees.FindAsync(id);
        if (entity is not null)
        {
            entity.IsAttended = isAttended;
        }
    }
}

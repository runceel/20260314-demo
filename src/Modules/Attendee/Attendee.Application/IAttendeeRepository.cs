using Attendee.Domain;

namespace Attendee.Application;

public interface IAttendeeRepository
{
    Task<IReadOnlyList<AttendeeEntity>> GetAllAsync();
    Task<AttendeeEntity?> GetAsync(int id);
    Task UpdateAttendanceAsync(int id, bool isAttended);
}

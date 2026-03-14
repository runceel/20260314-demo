namespace Attendee.Application.UseCases;

public interface IGetAttendeesUseCase
{
    Task<IReadOnlyList<AttendeeDto>> ExecuteAsync(string? searchText = null);
}

public class GetAttendeesUseCase(IAttendeeRepository repository) : IGetAttendeesUseCase
{
    public async Task<IReadOnlyList<AttendeeDto>> ExecuteAsync(string? searchText = null)
    {
        var entities = await repository.GetAllAsync();

        var filtered = string.IsNullOrEmpty(searchText)
            ? entities
            : entities.Where(e => e.AccountName.Contains(searchText, StringComparison.OrdinalIgnoreCase)).ToList();

        return filtered.Select(e => new AttendeeDto(e.ID, e.AccountName, e.IsAttended)).ToList();
    }
}

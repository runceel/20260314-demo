using Attendee.Application;
using Attendee.Application.UseCases;

namespace Web.Components.Pages;

public partial class Attendees(
    IGetAttendeesUseCase getAttendeesUseCase,
    IUpdateAttendanceUseCase updateAttendanceUseCase)
{
    private List<AttendeeDto> attendees = [];
    private string searchText = "";

    private IQueryable<AttendeeDto> filteredAttendees =>
        string.IsNullOrEmpty(searchText)
            ? attendees.AsQueryable()
            : attendees.Where(a => a.AccountName.Contains(searchText, StringComparison.OrdinalIgnoreCase)).AsQueryable();

    protected override async Task OnInitializedAsync()
    {
        await LoadAttendeesAsync();
    }

    private async Task OnSearchTextChanged()
    {
        await Task.CompletedTask;
    }

    private async Task OnAttendanceChanged(int id, bool isAttended)
    {
        await updateAttendanceUseCase.ExecuteAsync(id, isAttended);
        await LoadAttendeesAsync();
    }

    private async Task LoadAttendeesAsync()
    {
        var result = await getAttendeesUseCase.ExecuteAsync();
        attendees = result.ToList();
    }
}

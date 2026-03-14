namespace Attendee.Application.UseCases;

public interface IUpdateAttendanceUseCase
{
    Task ExecuteAsync(int id, bool isAttended);
}

public class UpdateAttendanceUseCase(IAttendeeRepository repository, IUnitOfWork unitOfWork) : IUpdateAttendanceUseCase
{
    public async Task ExecuteAsync(int id, bool isAttended)
    {
        await repository.UpdateAttendanceAsync(id, isAttended);
        await unitOfWork.SaveChangesAsync();
    }
}

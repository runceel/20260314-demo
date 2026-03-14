namespace Counter.Application.UseCases;

public interface IResetCounterUseCase
{
    Task ExecuteAsync(int id);
}

public class ResetCounterUseCase(ICounterRepository repository, IUnitOfWork unitOfWork) : IResetCounterUseCase
{
    public async Task ExecuteAsync(int id)
    {
        var entity = await repository.GetAsync(id);
        if (entity is not null)
        {
            entity.Reset();
            await unitOfWork.SaveChangesAsync();
        }
    }
}

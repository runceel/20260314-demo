namespace Counter.Application.UseCases;

public interface IIncrementCounterUseCase
{
    Task ExecuteAsync(int id);
}

public class IncrementCounterUseCase(ICounterRepository repository, IUnitOfWork unitOfWork) : IIncrementCounterUseCase
{
    public async Task ExecuteAsync(int id)
    {
        var entity = await repository.GetAsync(id);
        if (entity is not null)
        {
            entity.Increment();
            await unitOfWork.SaveChangesAsync();
        }
    }
}

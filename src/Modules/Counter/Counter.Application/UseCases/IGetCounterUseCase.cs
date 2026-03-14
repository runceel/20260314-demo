namespace Counter.Application.UseCases;

public interface IGetCounterUseCase
{
    Task<CounterDto?> ExecuteAsync(int id);
}

public class GetCounterUseCase(ICounterRepository repository) : IGetCounterUseCase
{
    public async Task<CounterDto?> ExecuteAsync(int id)
    {
        var entity = await repository.GetAsync(id);
        if (entity is null) return null;
        return new CounterDto(entity.ID, entity.CurrentCount);
    }
}

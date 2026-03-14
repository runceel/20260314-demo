using Counter.Domain;

namespace Counter.Application;

public interface ICounterRepository
{
    Task<CounterEntity?> GetAsync(int id);
}

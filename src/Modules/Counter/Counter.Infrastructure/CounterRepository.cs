using Counter.Domain;

namespace Counter.Infrastructure;

public class CounterRepository(CounterDbContext dbContext) : Application.ICounterRepository
{
    public async Task<CounterEntity?> GetAsync(int id)
    {
        return await dbContext.Counters.FindAsync(id);
    }
}

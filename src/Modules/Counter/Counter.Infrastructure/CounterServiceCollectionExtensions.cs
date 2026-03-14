using Counter.Application;
using Counter.Application.UseCases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Counter.Infrastructure;

public static class CounterServiceCollectionExtensions
{
    public static IServiceCollection AddCounterModule(this IServiceCollection services)
    {
        services.AddDbContext<CounterDbContext>(options =>
            options.UseInMemoryDatabase("CounterDb"));
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CounterDbContext>());

        services.AddScoped<ICounterRepository, CounterRepository>();

        services.AddScoped<IGetCounterUseCase, GetCounterUseCase>();
        services.AddScoped<IIncrementCounterUseCase, IncrementCounterUseCase>();
        services.AddScoped<IResetCounterUseCase, ResetCounterUseCase>();

        return services;
    }
}

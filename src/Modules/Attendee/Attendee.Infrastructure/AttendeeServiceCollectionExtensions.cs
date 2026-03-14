using Attendee.Application;
using Attendee.Application.UseCases;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Attendee.Infrastructure;

public static class AttendeeServiceCollectionExtensions
{
    public static IServiceCollection AddAttendeeModule(this IServiceCollection services)
    {
        services.AddDbContext<AttendeeDbContext>(options =>
            options.UseInMemoryDatabase("AttendeeDb"));
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AttendeeDbContext>());

        services.AddScoped<IAttendeeRepository, AttendeeRepository>();

        services.AddScoped<IGetAttendeesUseCase, GetAttendeesUseCase>();
        services.AddScoped<IUpdateAttendanceUseCase, UpdateAttendanceUseCase>();

        return services;
    }
}

using Attendee.Infrastructure;
using Counter.Infrastructure;
using Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCounterModule();
builder.Services.AddAttendeeModule();

var app = builder.Build();

// Ensure InMemory database is created with seed data.
using (var scope = app.Services.CreateScope())
{
    var counterDbContext = scope.ServiceProvider.GetRequiredService<CounterDbContext>();
    counterDbContext.Database.EnsureCreated();

    var attendeeDbContext = scope.ServiceProvider.GetRequiredService<AttendeeDbContext>();
    attendeeDbContext.Database.EnsureCreated();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

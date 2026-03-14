using Counter.Application;
using Counter.Application.UseCases;

namespace Web.Components.Pages;

public partial class Counter(
    IGetCounterUseCase getCounterUseCase,
    IIncrementCounterUseCase incrementCounterUseCase,
    IResetCounterUseCase resetCounterUseCase)
{
    private int currentCount;
    private const int CounterId = 1;

    protected override async Task OnInitializedAsync()
    {
        await LoadCounterAsync();
    }

    private async Task IncrementCount()
    {
        await incrementCounterUseCase.ExecuteAsync(CounterId);
        await LoadCounterAsync();
    }

    private async Task ResetCount()
    {
        await resetCounterUseCase.ExecuteAsync(CounterId);
        await LoadCounterAsync();
    }

    private async Task LoadCounterAsync()
    {
        var counter = await getCounterUseCase.ExecuteAsync(CounterId);
        currentCount = counter?.CurrentCount ?? 0;
    }
}

namespace Counter.Domain;

public class CounterEntity
{
    public int ID { get; set; }
    public int CurrentCount { get; set; }

    public void Increment()
    {
        CurrentCount++;
    }

    public void Reset()
    {
        CurrentCount = 0;
    }
}

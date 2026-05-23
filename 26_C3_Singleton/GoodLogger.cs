public interface ILoggerService
{
    void Log(string message);
    Guid Id { get; }
}

public class GoodLoggerService : ILoggerService
{
    public Guid Id { get; } = Guid.NewGuid();

    public void Log(string message)
    {
        Console.WriteLine($"[{Id}] {message}");
    }
}
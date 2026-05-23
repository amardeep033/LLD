// Lazy<T> defers construction until .Value is first accessed.
// Lazy<T> handles thread-safety internally using double-checked locking under the hood.

sealed class LazyLogger
{
    private static readonly Lazy<LazyLogger> _lazy = new Lazy<LazyLogger>(() => new LazyLogger());

    private LazyLogger()
    {
        Console.WriteLine("Lazy Logger instance created");
    }

    //created here -- on first access to .Instance
    public static LazyLogger Instance
    {
        get => _lazy.Value;
    } 

    public void Log(string message)
    {
        Console.WriteLine($"LAZY LOG: {message}");
    }

    public static bool IsLazyLoggerCreated => _lazy.IsValueCreated; //just to check
}
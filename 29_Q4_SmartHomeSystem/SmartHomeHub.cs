public sealed class SmartHomeHub
{
    private static readonly Lazy<SmartHomeHub> _lazy = new Lazy<SmartHomeHub>(() => new SmartHomeHub());

    private readonly Home home;
    private readonly Remote remote;

    private SmartHomeHub()
    {
        this.home = new Home("Amardeep's Home");
        this.remote = new Remote();
        Console.WriteLine("SmartHomeHub instance created");
    }

    public static SmartHomeHub Instance => _lazy.Value;

    public Home GetHome() => home;
    public Remote GetRemote() => remote;

    public static bool IsSmartHomeHubCreated => _lazy.IsValueCreated; 
}
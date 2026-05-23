public class BadFile
{
    private readonly string name;

    public BadFile(string name)
    {
        this.name = name;
    }

    public void Show()
    {
        Console.WriteLine($"File: {name}");
    }
}
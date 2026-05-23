public class File : IFileSystemItem
{
    private readonly string name;

    public File(string name)
    {
        this.name = name;
    }

    public void Show()
    {
        Console.WriteLine($"File: {name}");
    }
}
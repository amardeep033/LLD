public class Room : IStructure
{
    private readonly string name;
    private readonly List<IStructure> items = new();

    public Room(string name)
    {
        this.name = name;
    }

    public void Add(IStructure item)
    {
        items.Add(item);
    }

    public void Remove(IStructure item)
    {
        items.Remove(item);
    }

    public void Show()
    {
        Console.WriteLine($"Room: {name}");

        foreach (var item in items)
        {
            item.Show();
        }
    }

    public void On()
    {
        Console.WriteLine($"Room Level ON Command: {name}");
        foreach (var item in items)
        {
            item.On();
        }
    }

    public void Off()
    {
        Console.WriteLine($"Room Level OFF Command: {name}");
        foreach (var item in items)
        {
            item.Off();
        }
    }
}
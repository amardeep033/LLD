public class Home : IStructure
{
    private readonly string name;
    private readonly List<IStructure> items = new();

    public Home(String name)
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
        Console.WriteLine($"Home: {name}");

        foreach (var item in items)
        {
            item.Show();
        }
    }

    public void On()
    {
        Console.WriteLine($"Home Level ON Command: {name}");
        foreach (var item in items)
        {
            item.On();
        }
    }

    public void Off()
    {
        Console.WriteLine($"Home Level OFF Command: {name}");
        foreach (var item in items)
        {
            item.Off();
        }
    }
}
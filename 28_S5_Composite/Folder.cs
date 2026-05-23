public class Folder : IFileSystemItem
{
    private readonly string name;

    //the items can be either file or folder -- we are treating them same -- open, close, delete etc. -- we are not treating them differently
    //also its not tightly coupled with file -- we can have any type of item in folder
    //also lets say some nested structure like manager: sde, sdet and tmrw if something new comes like qa then we dont need to change manager class - as it will be employeeType

    private readonly List<IFileSystemItem> items = new();

    public Folder(string name)
    {
        this.name = name;
    }

    public void Add(IFileSystemItem item)
    {
        items.Add(item);
    }

    public void Remove(IFileSystemItem item)
    {
        items.Remove(item);
    }

    public void Show()
    {
        Console.WriteLine($"Folder: {name}");

        foreach (var item in items)
        {
            item.Show();
        }
    }
}
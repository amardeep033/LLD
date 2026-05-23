public class BadFolder
{
    private readonly string name;

    //folder cant contain folder(itself) -- containing folder is impossible
    //also lets say some nested structure like manager: sde, sdet and tmrw if something new comes like qa then we need to change manager class
    //we want to treat files and folders same : open, close, delete etc. but here we are treating them differently
    //also files is tightly coupled with folder
    private readonly List<BadFile> files = new();

    public BadFolder(string name)
    {
        this.name = name;
    }

    public void AddFile(BadFile file)
    {
        files.Add(file);
    }

    public void Show()
    {
        Console.WriteLine($"Folder: {name}");

        foreach (var file in files)
        {
            file.Show();
        }
    }
}
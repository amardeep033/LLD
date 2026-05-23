public class Light : Device
{
    private string name;

    public Light(string name)
    {
        this.name = name;
    }

    public override void Show()
    {
        Console.WriteLine($"Light: {name}");
    }

    public override void On()
    {
        Console.WriteLine($"Turning on {name}");
    }

    public override void Off()
    {
        Console.WriteLine($"Turning off {name}");
    }
}
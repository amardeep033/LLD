public class Fan : Device
{
    private string name;

    public Fan(string name)
    {
        this.name = name;
    }

    public override void Show()
    {
        Console.WriteLine($"Fan: {name}");
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
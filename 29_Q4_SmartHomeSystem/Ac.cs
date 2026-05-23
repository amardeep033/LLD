public class Ac : Device
{
    private string name;
    private int current_temperature = 24; // default temperature
    private bool is_on = false;

    public Ac(string name)
    {
        this.name = name;
    }

    public int GetCurrentTemperature()
    {
        return current_temperature;
    }

    public override void Show()
    {
        Console.WriteLine($"Ac: {name}");
    }

    public override void On()
    {
        is_on = true;
        Console.WriteLine($"Turning on {name}");
    }

    public override void Off()
    {
        is_on = false;
        Console.WriteLine($"Turning off {name}");
    }

    //to access setTemp -- we need to pass type AC and not IDevice
    public void setTemperature(int temperature)
    {
        if (!is_on)
        {
            Console.WriteLine($"Cannot set temperature. {name} is off.");
            return;
        }
        Console.WriteLine($"Setting {name} temperature from {GetCurrentTemperature()} to {temperature} degrees");
        this.current_temperature = temperature;
    }
}
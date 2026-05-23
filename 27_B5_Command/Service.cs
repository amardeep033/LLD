using System;

public class Light : ILightCommand
{
    public void On()
    {
        Console.WriteLine("Light ON");
    }

    public void Off()
    {
        Console.WriteLine("Light OFF");
    }
}

public class Fan : IFanCommand
{
    public void On()
    {
        Console.WriteLine("Fan ON");
    }

    public void Pause()
    {
        Console.WriteLine("Fan PAUSE");
    }

    public void Off()
    {
        Console.WriteLine("Fan OFF");
    }
}
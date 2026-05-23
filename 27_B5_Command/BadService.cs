using System;

public class BadLight
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

public class BadFan
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
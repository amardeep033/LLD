using System;

class BadLogger
{
    public BadLogger()
    {
        Console.WriteLine("Logger instance created");
    }

    public void Log(string message)
    {
        Console.WriteLine($"LOG: {message}");
    }
}
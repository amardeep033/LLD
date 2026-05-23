using System;

// Sealed classes are used to restrict the users from inheriting the class and creating multiple instances of the class. It is used to implement the singleton pattern in a thread-safe way without using locks or other synchronization mechanisms.
sealed class Logger
{
    //private static readonly variable to hold the single instance of Logger - property instead of method(not thread safe) or member variable with lazy initialization(not thread safe)
    private static readonly Logger instance = new Logger();

    //constructor is private to prevent external instantiation
    private Logger()
    {
        Console.WriteLine("Logger instance created");
    }

    //public static property to provide global access to the single instance
    //not created here -- created at startup
    public static Logger Instance
    {
        get { return instance; }
    }

    public void Log(string message)
    {
        Console.WriteLine($"LOG: {message}");
    }
}
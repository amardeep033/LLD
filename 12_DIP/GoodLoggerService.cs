using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _12_DIP
{
    public class GoodLoggerService : ILoggerService
    {
        public void Log(string message)
        {
            Console.WriteLine("Logging to file: " + message);
        }
    }

    public class NewLoggerService : ILoggerService
    {
        public void Log(string message) =>
            Console.WriteLine("DB: " + message);
    }

}
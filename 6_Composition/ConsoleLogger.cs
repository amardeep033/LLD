using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_Composition
{
    public class ConsoleLogger : ILogger
    {
        public void Log(string message) =>
            Console.WriteLine($"[LOG] {message}");
    }

}
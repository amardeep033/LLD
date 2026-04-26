using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _12_DIP
{
    public interface ILoggerService
    {
            void Log(string message);
    }
}
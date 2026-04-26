using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17_B2_Observer
{
    public class BadSmsService
    {
        public void SendSms(string message)
        {
            Console.WriteLine($"SMS sent: {message}");
        }
    }
}
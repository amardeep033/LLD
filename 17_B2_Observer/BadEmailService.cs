using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17_B2_Observer
{
    public class BadEmailService
    {
        public void SendEmail(string message)
        {
            Console.WriteLine($"Email sent: {message}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5_Coupling
{
    public class GoodSmsSender : IGoodNotification
    {
        public void SendNotification(string to, string subject, string body)
        {
            Console.WriteLine($"Sending SMS to {to} with subject '{subject}' and body '{body}'");
        }
    }
}
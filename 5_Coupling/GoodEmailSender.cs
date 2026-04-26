using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5_Coupling
{
    public class GoodEmailSender : IGoodNotification
    {
        public void SendNotification(string to, string subject, string body)
        {
            Console.WriteLine($"Sending email to {to} with subject '{subject}' and body '{body}'");
        }
    }
}
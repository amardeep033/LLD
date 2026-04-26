using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5_Coupling
{
    public class BadEmailSender
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"Sending email to {to} with subject '{subject}' and body '{body}'");
        }
    }
}
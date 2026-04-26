using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2_Abstraction
{
    public class BadEmail
    {
            public void Authentication()
            {
                Console.WriteLine("Authenticating user.");
            }

            public void Connect()
            {
                Console.WriteLine("Connecting to email server.");
            }

            public void SendEmail()
            {
                Console.WriteLine("Sending email.");
            }

            public void Disconnect()
            {
                Console.WriteLine("Disconnecting from email server.");
            }
    }
}
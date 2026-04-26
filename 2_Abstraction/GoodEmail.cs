using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2_Abstraction
{
    public class GoodEmail
    {
        public void SendEmail()
        {
            Authentication();
            Connect();
            Console.WriteLine("Sending email.");
            Disconnect();
        }

        private void Authentication()
        {
            Console.WriteLine("Authenticating user.");
        }

        private void Connect()
        {
            Console.WriteLine("Connecting to email server.");
        }

        private void Disconnect()
        {
            Console.WriteLine("Disconnecting from email server.");
        }
    }
}
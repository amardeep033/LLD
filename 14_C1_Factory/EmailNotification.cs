using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _14_C1_Factory
{
    public class EmailNotification : INotification
    {
        private readonly string email;

        public EmailNotification(string email)
        {
            this.email = email;
        }

        public void Send(string message)
        {
            Console.WriteLine($"Email to {email}: {message}");
        }
    }
}
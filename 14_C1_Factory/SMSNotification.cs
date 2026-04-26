using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _14_C1_Factory
{
    public class SmsNotification : INotification
    {
        private readonly string phone;

        public SmsNotification(string phone)
        {
            this.phone = phone;
        }

        public void Send(string message)
        {
            Console.WriteLine($"SMS to {phone}: {message}");
        }
    }
}
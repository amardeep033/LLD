using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _20_Q2_EcomNotificationSystem
{
    public class SmsNotification : INotification
    {
        public NotificationChannel Channel => NotificationChannel.SMS;
        public void Send(Notification notification)
        {
            // No for loop for retry logic here - sender just sends, it doesn't know about retry or backup channels - all copy same retry logic
            Console.WriteLine($"[SMS] {notification}");
        }
    }
}
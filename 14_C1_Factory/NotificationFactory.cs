using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _14_C1_Factory
{

    public class NotificationContext
    {
        public string Type { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DeviceId { get; set; }
        public string AppId { get; set; }
    }

    public class NotificationFactory
    {
        public static INotification Create(NotificationContext ctx)
        {
            if (ctx.Type == "email")
            {
                return new EmailNotification(ctx.Email);
            }

            if (ctx.Type == "sms")
            {
                return new SmsNotification(ctx.Phone);
            }

            if (ctx.Type == "push")
            {
                return new PushNotification(ctx.DeviceId, ctx.AppId);
            }

            throw new Exception("Invalid notification type");
        }
    }
}
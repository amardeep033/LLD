using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _14_C1_Factory
{
    public class PushNotification : INotification
    {
        private readonly string deviceId;
        private readonly string appId;

        public PushNotification(string deviceId, string appId)
        {
            this.deviceId = deviceId;
            this.appId = appId;
        }

        public void Send(string message)
        {
            Console.WriteLine($"Push to device {deviceId} app {appId}: {message}");
        }
    }
}
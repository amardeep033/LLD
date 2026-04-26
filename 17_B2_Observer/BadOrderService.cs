using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _17_B2_Observer
{
    public class BadOrderService
    {
        private readonly BadEmailService _emailService;
        private readonly BadSmsService _smsService;

        public BadOrderService(BadEmailService emailService, BadSmsService smsService)
        {
            _emailService = emailService;
            _smsService = smsService;
        }

        public void PlaceOrder(string orderDetails)
        {
            Console.WriteLine($"Order placed: {orderDetails}");
            //Tightly coupled to email and sms services. If we want to add another notification service, we need to modify this class.
            _emailService.SendEmail($"Your order has been placed: {orderDetails}");
            _smsService.SendSms($"Your order has been placed: {orderDetails}");
        }
    }
}
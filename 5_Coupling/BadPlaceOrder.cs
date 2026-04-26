using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _5_Coupling
{
    public class BadPlaceOrder
    {
        public void PlaceOrder(string product, int quantity, string email)
        {
            Console.WriteLine($"Placing order for {quantity} of {product}");
            
            //creating object of email sender class inside place order class -- tightly coupled
            //tomorrow if we want to change the email sender class then we need to change the place order class also -- not good design
            //also if we want to send sms instead of email then we need to change the place order class also -- not good design

            BadEmailSender emailSender = new BadEmailSender();
            emailSender.SendEmail(email, "Order Confirmation", $"Your order for {quantity} of {product} has been placed successfully.");
        }
    }
}
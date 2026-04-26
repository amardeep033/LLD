using _16_Q1_PaymentProcessingSystem;

var factory = new PaymentFactory();
factory.Register("upi", config =>
    new UPIPayment(config["upiId"], config["password"]));
factory.Register("creditcard", config =>
    new CreditCardPayment(config["cardNumber"], config["cardHolderName"], config["expiryDate"], config["cvv"]));
//here itself we can register the adapter that wraps the external SDK under the hood, so client code doesn't need to know about the adapter or the external SDK at all
factory.Register("paypal", config =>
    new PaypalPayment(new PaypalExternalSDK(config["email"], config["password"])));


// UPI
IPayment upiProcessor = factory.CreatePaymentProcessor("upi", new Dictionary<string, string>
{
    { "upiId", "john.doe@upi" },
    { "password", "password123" }
});
new PaymentService(upiProcessor).ProcessPaymentService(50.00m);


// Credit Card
IPayment ccProcessor = factory.CreatePaymentProcessor("creditcard", new Dictionary<string, string>
{
    { "cardNumber", "1234 5678 9012 3456" },
    { "cardHolderName", "John Doe" },
    { "expiryDate", "12/25" },
    { "cvv", "123" }
});
new PaymentService(ccProcessor).ProcessPaymentService(100.00m);


// PayPal (Adapter wraps external SDK under the hood)
IPayment paypalProcessor = factory.CreatePaymentProcessor("paypal", new Dictionary<string, string>
{
    { "email", "john.doe@example.com" },
    { "password", "password123" }
});
new PaymentService(paypalProcessor).ProcessPaymentService(75.00m);
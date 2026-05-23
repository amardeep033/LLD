using System;

class BadPaymentService
{
    private BadLogger logger = new BadLogger();

    public void ProcessPayment()
    {
        logger.Log("Processing payment");
    }
}

class BadOrderService
{
    private BadLogger logger = new BadLogger();

    public void CreateOrder()
    {
        logger.Log("Creating order");
    }
}
class PaymentService
{
    public void ProcessPayment()
    {
        Logger.Instance.Log("Processing payment"); //lazy logger created here when .instance is accessed
        LazyLogger.Instance.Log("Processing payment");
    }
}

class OrderService
{
    public void CreateOrder()
    {
        Logger.Instance.Log("Creating order");
        LazyLogger.Instance.Log("Processing payment");
    }
}
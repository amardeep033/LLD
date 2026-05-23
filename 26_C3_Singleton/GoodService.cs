public class GoodPaymentService
{
    private readonly ILoggerService logger;

    public GoodPaymentService(ILoggerService logger)
    {
        this.logger = logger;
    }

    public void ProcessPayment()
    {
        logger.Log("Payment processed");
    }
}

public class GoodOrderService
{
    private readonly ILoggerService logger;

    public GoodOrderService(ILoggerService logger)
    {
        this.logger = logger;
    }

    public void CreateOrder()
    {
        logger.Log("Order created");
    }
}
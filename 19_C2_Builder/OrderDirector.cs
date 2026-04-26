namespace BuilderPattern
{
    // Director (optional): encapsulates common recipes - useful when same config is reused everywhere
    // e.g. in tests every standard order looks the same - director gives you one place to change it
    public class OrderDirector
    {
        private readonly OrderBuilder _builder;
        public OrderDirector(OrderBuilder builder) => _builder = builder;

        public GoodOrder BuildStandardOrder(string customer, string address) =>
            _builder
                .ForCustomer(customer)
                .DeliverTo(address)
                .Build();

        public GoodOrder BuildPremiumOrder(string customer, string address) =>
            _builder
                .ForCustomer(customer)
                .DeliverTo(address)
                .WithExpressShipping()
                .WithGiftWrap()
                .WithDiscount("PREMIUM20", 20)
                .Build();
        // new order type = new method here, zero changes anywhere else
    }
}
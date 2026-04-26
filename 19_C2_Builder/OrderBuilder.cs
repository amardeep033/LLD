namespace BuilderPattern
{
    // Builder: each method sets one thing and returns this - enables chaining
    // this is the fluent interface in action - same builder object flows through the chain
    public class OrderBuilder
    {
        private readonly GoodOrder _order = new GoodOrder();

        public OrderBuilder ForCustomer(string name)
        {
            _order.CustomerName = name;
            return this; // key: return builder not void - enables chaining
        }

        public OrderBuilder DeliverTo(string address)
        {
            _order.Address = address;
            return this;
        }

        public OrderBuilder WithExpressShipping()
        {
            _order.IsExpress = true;
            return this;
        }

        public OrderBuilder WithGiftWrap()
        {
            _order.IsGiftWrap = true;
            return this;
        }

        public OrderBuilder WithNotes(string notes)
        {
            _order.Notes = notes;
            return this;
        }

        public OrderBuilder WithDiscount(string couponCode, decimal amount)
        {
            _order.CouponCode = couponCode;
            _order.Discount = amount;
            return this;
        }

        // validation lives here - not in GoodOrder, not in caller - builder owns construction rules
        public GoodOrder Build()
        {
            if (string.IsNullOrEmpty(_order.CustomerName))
                throw new InvalidOperationException("Customer name is required");
            if (string.IsNullOrEmpty(_order.Address))
                throw new InvalidOperationException("Delivery address is required");

            return _order;
            // after this point GoodOrder is sealed - caller gets a clean immutable object
        }
    }
}
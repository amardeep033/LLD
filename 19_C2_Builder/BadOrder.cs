namespace BuilderPattern
{
    // BAD: telescoping constructor - grows with every new optional field
    // new BadOrder("John", "NYC", true, false, null, 10, "SAVE10") - what does true mean here?
    public class BadOrder
    {
        public string CustomerName { get; }
        public string Address { get; }
        public bool IsExpress { get; }
        public bool IsGiftWrap { get; }
        public string? Notes { get; }
        public decimal Discount { get; }
        public string? CouponCode { get; }

        public BadOrder(string customerName, string address, bool isExpress,
            bool isGiftWrap, string? notes, decimal discount, string? couponCode)
        {
            CustomerName = customerName;
            Address = address;
            IsExpress = isExpress;
            IsGiftWrap = isGiftWrap;
            Notes = notes;
            Discount = discount;
            CouponCode = couponCode;
        }
        // add one more field tomorrow = constructor change + every caller breaks
        // but having dictionary of options is worse - no type safety, no intellisense, more runtime errors
    }
}
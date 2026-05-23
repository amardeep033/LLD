//new discount type will modify the existing code - bad way of implementing
//interface + implementation + dynamic dispatch is the direction that satisfies the Open–Closed Principle.

class BadDiscount
{
    public double GetDiscount(string customerType, double amount)
    {
        if (customerType == "Regular")
            return amount * 0.1;

        if (customerType == "Premium")
            return amount * 0.2;

        return 0;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _9_OCP;

public class GoodDiscount
{
    public double Calculate(IGoodDiscount discount, double amount)
    {
        //dynamic dispatch -- Strategy Pattern
        return discount.GetDiscount(amount);
    }
}

//adding new discount is just another class which impl good discount contract

public class RegularDiscount : IGoodDiscount
{
    public double GetDiscount(double amount)
    {
        return amount * 0.1;
    }
}

public class PremiumDiscount : IGoodDiscount
{
    public double GetDiscount(double amount)
    {
        return amount * 0.2;
    }
}
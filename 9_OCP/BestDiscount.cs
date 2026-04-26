using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _9_OCP
{
    public class BestDiscount
    {
        public double Calculate(IBestDiscount discount, DiscountContext context)
        {
            //dynamic dispatch -- Strategy Pattern
            return discount.GetDiscount(context);
        }
    }

    public class RegularDiscount : IBestDiscount
    {
        public double GetDiscount(DiscountContext context)
        {
            return context.Amount * 0.1;
        }
    }

    public class FestivalDiscount : IBestDiscount
    {
        public double GetDiscount(DiscountContext context)
        {
            if (context.FestivalName == "Diwali")
                return context.Amount * 0.4;

            return context.Amount * 0.2;
        }
    }


}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _9_OCP
{
    public class DiscountContext
    {
        public double Amount { get; set; }
        public int CustomerYears { get; set; }
        public string FestivalName { get; set; }
        public string EmployeeGrade { get; set; }
    }

    public interface IBestDiscount
    {
        double GetDiscount(DiscountContext context);
    }
}
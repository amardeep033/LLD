using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _9_OCP
{
    public interface IGoodDiscount
    {
        double GetDiscount(double amount);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _6_Composition
{
    public interface IPaymentProcessor
    {
        bool ProcessPayment(decimal amount);
    }
}
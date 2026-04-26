using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _16_Q1_PaymentProcessingSystem
{
    public interface IPayment
    {
        decimal ProcessPayment(decimal amount);
    }
}
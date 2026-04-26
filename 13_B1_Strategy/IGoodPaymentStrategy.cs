using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace _13_B1_Strategy_Pattern
{
    public interface IGoodPaymentStrategy
    {
        void Pay(int amount);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_Inheritence
{
    public class BadSavingsAccount
    {
        public void OpenSavingsAccount()
        {
            Console.WriteLine("Opening Savings Account.");
        }

        public void DisplaySavingsBalance()
        {
            Console.WriteLine("Savings Account Balance: ₹5000");
        }
    }
}
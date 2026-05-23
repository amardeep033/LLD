using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3_Inheritence
{
    public class BadCurrentAccount
    {
        public void OpenCurrentAccount()
        {
            Console.WriteLine("Opening Current Account.");
        }

        public void DisplayCurrentBalance()
        {
            Console.WriteLine("Current Account Balance: ₹2000");
        }
    }
}
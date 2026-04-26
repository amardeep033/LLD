using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10_LSP
{
    public class BadAccountProcessor
    {
        public static void Process(BadAccount account)
        {
            account.Deposit(1000);
            account.Withdraw(200);

            // Client expects balance = 800
            Console.WriteLine("Balance: " + account.Balance);
        }
    }
}
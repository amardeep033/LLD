using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10_LSP
{
    public class GoodAccountProcessor
    {
        public static void Process(WithdrawableAccount account)
        {
            account.Deposit(1000);
            account.Withdraw(200);
            Console.WriteLine("Balance: " + account.Balance);
        }

    }
}
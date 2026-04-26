using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10_LSP
{
    public class GoodAccount
    {
        public decimal Balance { get; protected set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
    }

    public abstract class WithdrawableAccount : GoodAccount
    {
        public virtual void Withdraw(decimal amount)
        {
            Balance -= amount;
        }
    }

    class GoodSavingsAccount : WithdrawableAccount
    {
        // withdraw capability
    }

    class GoodDepositAccount : GoodAccount
    {
        // no withdraw capability
    }
}


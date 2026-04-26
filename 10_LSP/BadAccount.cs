using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _10_LSP
{
    public class BadAccount
    {
        public decimal Balance { get; protected set; }

        public virtual void Deposit(decimal amount) //virtual methods have a default implementation that derived classes can optionally override and abstract methods have no implementation and must be overridden
        {
            Balance += amount;
        }

        public virtual void Withdraw(decimal amount) //forces withdraw to be impl by all
        {
            Balance -= amount;
        }
    }

    public class BadSavingsAccount : BadAccount
    {
        //same bhvr as base
    }

    public class BadDepositAccount : BadAccount
    {
        public override void Withdraw(decimal amount)
        {
            // Withdrawal not allowed before maturity -- breaks same bhvr across
            Console.WriteLine("Withdrawal not allowed before maturity");
        }
    }
}
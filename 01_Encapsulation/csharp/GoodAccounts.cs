using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class GoodAccounts
    {
        //private field to store balance
        private decimal balance;
        
        // this is more idompotent and cleaner than having a private field and a public getter method - this is a property and not a field or method
        // public decimal Balance { get; private set; }

        // //private method to set balance - no need as balance should only be modified through deposit and withdraw methods
        // private void SetBalance(decimal amount)
        // {
        //     if (amount < 0)
        //     {
        //         throw new ArgumentException("Insufficient balance.");
        //     }
        //     balance = amount;
        // }

        // better to have a constructor to initialize balance instead of a setter method
        public GoodAccounts(decimal initialBalance = 0)
        {
            if (initialBalance < 0)
                throw new ArgumentException("Initial balance cannot be negative.");
            this.balance = initialBalance;
        }
        
        // public method to get balance
        public decimal GetBalance()
        {
            return balance;
        }

        // public method to deposit money
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Deposit amount must be positive");
            }

            // SetBalance(GetBalance() + amount);
            this.balance += amount;
        }

        // public method to withdraw money
        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Withdrawal amount must be positive");
            }


            if (amount > balance)
            {
                throw new InvalidOperationException("Insufficient funds");
            }
        
            // SetBalance(GetBalance() - amount);
            this.balance -= amount;
        }
    }
}
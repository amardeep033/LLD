using System;

namespace _4_BadPolymorphism
{
    public class BadAccounts
    {
        public void OpenAccount()
        {
            Console.WriteLine("Opening Bad Account.");
        }

        public void DisplayBalance()
        {
            Console.WriteLine("Account Balance: ₹-0");
        }

        public void CommonWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Bank!");
        }
    }

    public class BadSavingsAccount : BadAccounts
    {
        public void OpenAccount()
        {
            Console.WriteLine("Opening Bad Savings Account.");
        }

        public void DisplayBalance()
        {
            Console.WriteLine("Bad Savings Account Balance: ₹-5000");
        }

        public void BadAccountsOwnFunction()
        {
            Console.WriteLine("BadAccountsOwnFunction");
        }
    }
}
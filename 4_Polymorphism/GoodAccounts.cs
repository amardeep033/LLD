using System;

namespace _4_GoodPolymorphism
{
    public abstract class GoodAccounts
    {
        public abstract void OpenAccount();      
        public virtual void DisplayBalance()
        {
            Console.WriteLine("Default display balance!");
        }   

        // A shared method (optional)
        public void CommonWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Bank!");
        }
    }

    public class GoodSavingsAccount : GoodAccounts
    {
        public override void OpenAccount()
        {
            Console.WriteLine("Opening Good Savings Account.");
        }

        public override void DisplayBalance()
        {
            Console.WriteLine("Good Savings Account Balance: ₹5000");
        }

        public void GoodAccountsOwnFunction()
        {
            Console.WriteLine("GoodAccountsOwnFunction");
        }
    }

    public class GoodCurrentAccount : GoodAccounts
    {
        public override void OpenAccount() //forced to define
        {
            Console.WriteLine("Opening Good Current Account.");
        }

        public void GoodAccountsOwnFunction()
        {
            Console.WriteLine("GoodAccountsOwnFunction");
        }

    }
}
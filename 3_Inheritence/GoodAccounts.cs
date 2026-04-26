using System;

namespace _3_Inheritance
{
    // Base class
    public abstract class GoodAccounts
    {
        public abstract void OpenAccount();      // differs
        public abstract void DisplayBalance();   // differs

        // A shared method (optional)
        public void CommonWelcomeMessage()
        {
            Console.WriteLine("Welcome to the Bank!");
        }
    }

    // SavingsAccount overrides behaviors
    public class SavingsAccount : GoodAccounts
    {
        public override void OpenAccount()
        {
            Console.WriteLine("Opening Savings Account.");
        }

        //runtime polymorphism: same method name, different implementation based on account type
        public override void DisplayBalance()
        {
            Console.WriteLine("Savings Account Balance: ₹5000");
        }
    }

    // CurrentAccount overrides behaviors
    public class CurrentAccount : GoodAccounts
    {
        public override void OpenAccount()
        {
            Console.WriteLine("Opening Current Account.");
        }

        //runtime polymorphism: same method name, different implementation based on account type
        public override void DisplayBalance()
        {
            Console.WriteLine("Current Account Balance: ₹2000");
        }
    }
}
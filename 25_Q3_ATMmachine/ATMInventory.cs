namespace _25_Q3_ATMmachine
{
    public class ATMInventory
    {
        //init
        private Dictionary<int, int> _cashInventory;

        public ATMInventory(Dictionary<int, int> initialInventory)
        {
            _cashInventory = new Dictionary<int, int>(initialInventory);
        }

        //get total cash available
        public int GetTotalCash() =>
            _cashInventory.Sum(kv => kv.Key * kv.Value);

        public void PrintInventory()
        {
            Console.WriteLine("[ATM INVENTORY]");
            foreach (var kv in _cashInventory.OrderByDescending(k => k.Key))
                Console.WriteLine($"  ₹{kv.Key} × {kv.Value} notes = ₹{kv.Key * kv.Value}");
            Console.WriteLine($"  Total: ₹{GetTotalCash()}");
        }

        public bool DispenseCash(int userId, int amount, IBankService bank)
        {
            //1
            if (amount <= 0 || amount % 100 != 0)
            {
                Console.WriteLine($"[ERROR] Invalid amount. Please enter a valid amount in multiples of 100.");
                return false;
            } 
            if (GetTotalCash() == 0)
            {
                Console.WriteLine($"[ERROR] ATM is out of cash.");
                return false;
            }
            if (amount > GetTotalCash())
            {
                Console.WriteLine($"[ERROR] ATM does not have enough cash to dispense the requested amount. Try a smaller amount.");
                return false;
            }

            //2
            var dispenseProcessor = Factory.Create();
            if (dispenseProcessor.CanDispense(amount, _cashInventory) != 0)
            {
                Console.WriteLine($"[ERROR] ATM cannot dispense the requested amount with available inventory. Try a different amount.");
                return false;
            } 
           
            //3
            bool debited = bank.Debit(userId, amount);
            if (!debited)
            {
                Console.WriteLine($"[ATM] Bank declined the transaction for ₹{amount}.");
                return false;
            }

            //4
            Console.WriteLine($"[ATM] Dispensing ₹{amount}:");
            dispenseProcessor.Deduct(amount, _cashInventory);
            Console.WriteLine($"[ATM] Please collect your cash. Remaining ATM cash: ₹{GetTotalCash()}");
            return true;
        }
    }
}
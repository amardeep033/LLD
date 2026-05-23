namespace _25_Q3_ATMmachine
{
    // ─── ₹2000 ──────────────────────────────────────────────────────────────────
    public class Denomination2000 : DenominationHandler
    {
        private const int Value = 2000;

        public override int CanDispense(int amount, Dictionary<int, int> cashInventory)
        {
            int available = cashInventory.GetValueOrDefault(Value, 0);
            int toUse = Math.Min(amount / Value, available);
            return HandleCanDispenseNext(amount - toUse * Value, cashInventory);
        }

        public override void Deduct(int amount, Dictionary<int, int> cashInventory)
        {
            int available = cashInventory.GetValueOrDefault(Value, 0);
            int toUse = Math.Min(amount / Value, available);
            if (toUse > 0)
            {
                cashInventory[Value] -= toUse;
                Console.WriteLine($"  Dispensing {toUse} × ₹{Value}");
            }
            HandleDeductNext(amount - toUse * Value, cashInventory);
        }
    }


    // ─── ₹500 ───────────────────────────────────────────────────────────────────
    public class Denomination500 : DenominationHandler
    {
        private const int Value = 500;

        public override int CanDispense(int amount, Dictionary<int, int> cashInventory)
        {
            int available = cashInventory.GetValueOrDefault(Value, 0);
            int toUse = Math.Min(amount / Value, available);
            return HandleCanDispenseNext(amount - toUse * Value, cashInventory);
        }

        public override void Deduct(int amount, Dictionary<int, int> cashInventory)
        {
            int available = cashInventory.GetValueOrDefault(Value, 0);
            int toUse = Math.Min(amount / Value, available);
            if (toUse > 0)
            {
                cashInventory[Value] -= toUse;
                Console.WriteLine($"  Dispensing {toUse} × ₹{Value}");
            }
            HandleDeductNext(amount - toUse * Value, cashInventory);
        }
    }


    // ─── ₹200 ───────────────────────────────────────────────────────────────────
    public class Denomination200 : DenominationHandler
    {
        private const int Value = 200;

        public override int CanDispense(int amount, Dictionary<int, int> cashInventory)
        {
            int available = cashInventory.GetValueOrDefault(Value, 0);
            int toUse = Math.Min(amount / Value, available);
            return HandleCanDispenseNext(amount - toUse * Value, cashInventory);
        }

        public override void Deduct(int amount, Dictionary<int, int> cashInventory)
        {
            int available = cashInventory.GetValueOrDefault(Value, 0);
            int toUse = Math.Min(amount / Value, available);
            if (toUse > 0)
            {
                cashInventory[Value] -= toUse;
                Console.WriteLine($"  Dispensing {toUse} × ₹{Value}");
            }
            HandleDeductNext(amount - toUse * Value, cashInventory);
        }
    }
    

    // ─── ₹100 ───────────────────────────────────────────────────────────────────
    public class Denomination100 : DenominationHandler
    {
        private const int Value = 100;

        public override int CanDispense(int amount, Dictionary<int, int> cashInventory)
        {
            int available = cashInventory.GetValueOrDefault(Value, 0);
            int toUse = Math.Min(amount / Value, available);
            return HandleCanDispenseNext(amount - toUse * Value, cashInventory);
        }

        public override void Deduct(int amount, Dictionary<int, int> cashInventory)
        {
            int available = cashInventory.GetValueOrDefault(Value, 0);
            int toUse = Math.Min(amount / Value, available);
            if (toUse > 0)
            {
                cashInventory[Value] -= toUse;
                Console.WriteLine($"  Dispensing {toUse} × ₹{Value}");
            }
            HandleDeductNext(amount - toUse * Value, cashInventory);
        }
    }
}
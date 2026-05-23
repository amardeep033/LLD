namespace _25_Q3_ATMmachine
{
    public abstract class DenominationHandler : IDenominationHandler
    {
        protected IDenominationHandler? next;

        public IDenominationHandler SetNext(IDenominationHandler nextHandler)
        {
            next = nextHandler;
            return nextHandler;
        }

        public abstract int CanDispense(int amount, Dictionary<int, int> cashInventory);

        public abstract void Deduct(int amount, Dictionary<int, int> cashInventory);

        protected int HandleCanDispenseNext(int remaining, Dictionary<int, int> cashInventory)
        {
            if (next != null && remaining > 0)
                return next.CanDispense(remaining, cashInventory);

            return remaining;
        }

        protected void HandleDeductNext(int remaining, Dictionary<int, int> cashInventory)
        {
            if (next != null && remaining > 0)
                next.Deduct(remaining, cashInventory);

            return;
        }
    }
}
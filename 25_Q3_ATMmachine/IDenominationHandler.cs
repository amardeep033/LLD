namespace _25_Q3_ATMmachine
{
    public interface IDenominationHandler
    {
        public int CanDispense(int amount, Dictionary<int, int> cashInventory);

        public void Deduct(int amount, Dictionary<int, int> cashInventory);

        public IDenominationHandler SetNext(IDenominationHandler nextHandler);
    }
}
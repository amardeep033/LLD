namespace _25_Q3_ATMmachine
{
    // Facade pattern:
    // The terminal / client code only ever calls ATMFacade.
    // It knows nothing about ATMService, ATMInventory, BankServiceProxy,
    // DenominationChainFactory, or individual states.
    //
    // Subsystems hidden behind the facade:
    //   - CardReader       (simulated inside InsertCard)
    //   - PinPad           (simulated inside EnterPin)
    //   - CashDispenser    (ATMInventory + denomination chain)
    //   - BankNetwork      (RealBankService via BankServiceProxy)
    //   - ReceiptPrinter   (simulated inside PrintReceipt)
    public class ATMFacade
    {
        private readonly ATMService _atm;
        private readonly ATMInventory _inventory;

        // Facade wires everything together internally
        public ATMFacade(int atmId)
        {
            var realBank = new RealBankService();
            var proxy    = new BankServiceProxy(realBank);

            _atm = new ATMService(atmId, proxy);
            _inventory = new ATMInventory(new Dictionary<int, int>
            {
                { 2000, 10 },   // 10 × ₹2000 = ₹20,000
                { 500,  20 },   // 20 × ₹500  = ₹10,000
                { 200,  30 },   // 30 × ₹200  =  ₹6,000
                { 100,  50 },   // 50 × ₹100  =  ₹5,000
            });
        }

        // ── Terminal-facing operations ───────────────────────────────────────────
        public void InsertCard(int userId)
        {
            Console.WriteLine("── INSERT CARD ──────────────────────────");
            _atm.ActionInsertCard(userId);
            _atm.PrintStatus();
        }

        public void EnterPin(int pin)
        {
            Console.WriteLine("── ENTER PIN ────────────────────────────");
            _atm.ActionEnterPin(pin);
            _atm.PrintStatus();
        }

        public void CheckBalance()
        {
            Console.WriteLine("── CHECK BALANCE ────────────────────────");
            _atm.ActionCheckBalance();
        }

        public void WithdrawCash(int amount)
        {
            Console.WriteLine($"── WITHDRAW ₹{amount} ──────────────────────");
            _atm.ActionDispenseCash(_inventory, amount);
            _atm.PrintStatus();
            if (_atm.Status == ATMStatus.StatusIdle)
                PrintReceipt(_atm.ActiveUserId, amount);
        }

        public void Cancel()
        {
            Console.WriteLine("── CANCEL ───────────────────────────────");
            _atm.ActionCancel();
            _atm.PrintStatus();
        }

        public void ShowInventory() => _inventory.PrintInventory();

        // ── Private subsystems ───────────────────────────────────────────────────
        private void PrintReceipt(int userId, int amount)
        {
            Console.WriteLine("════════════════════════════════════════");
            Console.WriteLine($"          ATM RECEIPT");
            Console.WriteLine($"  ATM ID     : {_atm.Id}");
            Console.WriteLine($"  User       : {userId}");
            Console.WriteLine($"  Withdrawn  : ₹{amount}");
            Console.WriteLine($"  Date/Time  : {DateTime.Now:dd-MMM-yyyy HH:mm}");
            Console.WriteLine("════════════════════════════════════════");
        }
    }
}
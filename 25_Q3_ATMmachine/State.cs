namespace _25_Q3_ATMmachine
{
    public class StatusIdle : IATMState
    {
        public ATMStatus Status => ATMStatus.StatusIdle;

        public void ActionInsertCard(ATMService atm)
        {
            Console.WriteLine($"Card inserted into ATM {atm.Id}.");
            atm.SetState(new StatusCardInserted());
        }

        public void ActionEnterPin(ATMService atm, int pin) =>
            Console.WriteLine($"[ERROR] ATM {atm.Id} is Idle — insert card first.");

        public void ActionCheckBalance(ATMService atm, IBankService bank) =>
            Console.WriteLine($"[ERROR] ATM {atm.Id} is Idle — insert card first.");

        //why all other args?
        public void ActionDispenseCash(ATMService atm, ATMInventory inventory, IBankService bank, int amount) =>
            Console.WriteLine($"[ERROR] ATM {atm.Id} is Idle — insert card first.");

        public void ActionCancel(ATMService atm)
        {
            Console.WriteLine($"[ERROR] ATM {atm.Id} is Idle — no operation to cancel.");
        }
    }

    //-------------

    public class StatusCardInserted : IATMState
    {

        private int _pinAttempts = 0;
        private const int MaxAttempts = 3;
        public ATMStatus Status => ATMStatus.StatusCardInserted;

        public void ActionInsertCard(ATMService atm) =>
           Console.WriteLine($"[ERROR] ATM {atm.Id} is already Card Inserted — cannot insert another card.");

        public void ActionEnterPin(ATMService atm, int pin)
        {             
            _pinAttempts++;

            //check
            bool valid = atm.Bank.ValidatePin(atm.ActiveUserId, pin);

            if (valid)
            {
                Console.WriteLine($"[ATM {atm.Id}] PIN accepted. Welcome!");
                atm.SetState(new StatusAuthenticated());
            }
            else if (_pinAttempts >= MaxAttempts)
            {
                Console.WriteLine($"[ATM {atm.Id}] 3 wrong PINs. Card blocked. Ejecting.");
                atm.Bank.BlockCard(atm.ActiveUserId);
                atm.SetState(new StatusIdle());
            }
            else
            {
                Console.WriteLine($"[ATM {atm.Id}] Wrong PIN. {MaxAttempts - _pinAttempts} attempt(s) remaining.");
            }
        }

        public void ActionCheckBalance(ATMService atm, IBankService bank) =>
            Console.WriteLine($"[ERROR] ATM {atm.Id} is Card Inserted — enter PIN first.");

        public void ActionDispenseCash(ATMService atm, ATMInventory inventory, IBankService bank, int amount) =>
            Console.WriteLine($"[ERROR] ATM {atm.Id} is Card Inserted — enter PIN first.");

        public void ActionCancel(ATMService atm)
        {
            Console.WriteLine($"Ejecting card from ATM {atm.Id}.");
            atm.SetState(new StatusIdle());
        }
    }

    //-------------

    public class StatusAuthenticated : IATMState
    {
        public ATMStatus Status => ATMStatus.StatusAuthenticated;

        public void ActionInsertCard(ATMService atm) =>
           Console.WriteLine($"[ERROR] ATM {atm.Id} is already authenticated — cannot insert another card.");

        public void ActionEnterPin(ATMService atm, int pin) =>
            Console.WriteLine($"[ERROR] ATM {atm.Id} is already authenticated — cannot enter PIN again.");

        public void ActionCheckBalance(ATMService atm, IBankService bank)
        {
            Console.WriteLine($"Checking balance on ATM {atm.Id}.");
            atm.SetState(new StatusAuthenticated()); // Remain in the same state
        }

        public void ActionDispenseCash(ATMService atm, ATMInventory inventory, IBankService bank, int amount)
        {
            atm.SetState(new StatusDispensingCash());

            //check
            bool success = inventory.DispenseCash(atm.ActiveUserId, amount, bank);

            if (success && inventory.GetTotalCash() == 0)
            {
                Console.WriteLine($"[ATM {atm.Id}] ATM is now out of cash.");
                atm.SetState(new StatusOutOfCash());
            }
            else
            {
                // Return to idle (eject card) after transaction
                atm.SetState(new StatusIdle());
            }
        }

        public void ActionCancel(ATMService atm)
        {
            Console.WriteLine($"Ejecting card from ATM {atm.Id}.");
            atm.SetState(new StatusIdle());
        }
    }

    //-------------

    public class StatusDispensingCash : IATMState
    {
        public ATMStatus Status => ATMStatus.StatusDispensingCash;

        public void ActionInsertCard(ATMService atm) =>
           Console.WriteLine($"[ERROR] ATM {atm.Id} is already dispensing cash — cannot insert another card.");

        public void ActionEnterPin(ATMService atm, int pin) =>
            Console.WriteLine($"[ERROR] ATM {atm.Id} is already dispensing cash — cannot enter PIN again.");

        public void ActionCheckBalance(ATMService atm, IBankService bank) =>
            Console.WriteLine($"[ERROR] ATM {atm.Id} is already dispensing cash — cannot check balance.");

        public void ActionDispenseCash(ATMService atm, ATMInventory inventory, IBankService bank, int amount) =>
            Console.WriteLine($"[ERROR] ATM {atm.Id} is already dispensing cash — cannot dispense cash again.");

        public void ActionCancel(ATMService atm) =>
            Console.WriteLine($"[ERROR] ATM {atm.Id} is already dispensing cash — cannot cancel.");

    }

    //-------------

    public class StatusOutOfCash : IATMState
    {
        public ATMStatus Status => ATMStatus.StatusOutOfCash;

        public void ActionInsertCard(ATMService atm) =>
            Console.WriteLine($"[ATM {atm.Id}] This ATM is out of cash. Please use another ATM.");

        public void ActionEnterPin(ATMService atm, int pin) =>
            Console.WriteLine($"[ATM {atm.Id}] This ATM is out of cash.");

        public void ActionCheckBalance(ATMService atm, IBankService bank) =>
            Console.WriteLine($"[ATM {atm.Id}] This ATM is out of cash.");

        public void ActionDispenseCash(ATMService atm, ATMInventory inventory, IBankService bank, int amount) =>
            Console.WriteLine($"[ATM {atm.Id}] ERROR: ATM is out of cash. Cannot dispense.");

        public void ActionCancel(ATMService atm) =>
            Console.WriteLine($"[ATM {atm.Id}] ERROR: No active session.");
    }
}
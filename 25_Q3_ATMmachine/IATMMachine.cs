namespace _25_Q3_ATMmachine
{
    public enum ATMStatus
    {
        StatusIdle,
        StatusCardInserted,
        StatusAuthenticated,
        StatusDispensingCash,
        StatusOutOfCash
    }

    public interface IATMState
    {
        ATMStatus Status { get; }
        void ActionInsertCard(ATMService atm);
        void ActionEnterPin(ATMService atm, int pin);
        void ActionCheckBalance(ATMService atm, IBankService bank);
        void ActionDispenseCash(ATMService atm, ATMInventory inventory, IBankService bank, int amount);
        void ActionCancel(ATMService atm);
    }
}
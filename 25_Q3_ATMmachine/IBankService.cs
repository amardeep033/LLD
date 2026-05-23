namespace _25_Q3_ATMmachine
{
    public interface IBankService
    {
        bool ValidatePin(int userId, int pin);
        int GetBalance(int userId);
        bool Debit(int userId, int amount);   // returns false if insufficient funds
        void BlockCard(int userId);
        int GetDailyLimit(int userId);
        int GetAmountWithdrawnToday(int userId);
        void LogTransaction(int userId, int amount, bool success, string reason);
    }
}
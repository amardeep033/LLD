namespace _25_Q3_ATMmachine
{
    // Simulates an actual bank's backend — network calls, DB queries, etc.
    // In a real system this would call bank APIs over the network.
    public class RealBankService : IBankService
    {
        // Simulated user data store: userId → (pin, balance, blocked, dailyLimit, withdrawnToday)
        private class UserAccount
        {
            public int Pin { get; set; }
            public int Balance { get; set; }
            public bool IsBlocked { get; set; }
            public int DailyLimit { get; set; }
            public int WithdrawnToday { get; set; }
        }

        private readonly Dictionary<int, UserAccount> _accounts = new()
        {
            { 1001, new UserAccount { Pin = 1234, Balance = 50000, IsBlocked = false, DailyLimit = 10000, WithdrawnToday = 0 } },
            { 1002, new UserAccount { Pin = 5678, Balance = 2000,  IsBlocked = false, DailyLimit = 10000, WithdrawnToday = 0 } },
        };

        public bool ValidatePin(int userId, int pin)
        {
            if (!_accounts.TryGetValue(userId, out var acc)) return false;
            if (acc.IsBlocked) 
            {
                Console.WriteLine($"[BANK] Account {userId} is blocked.");
                return false;
            }
            return acc.Pin == pin;
        }

        public int GetBalance(int userId)
        {
            if (!_accounts.TryGetValue(userId, out var acc)) return 0;
            return acc.Balance;
        }

        public bool Debit(int userId, int amount)
        {
            if (!_accounts.TryGetValue(userId, out var acc)) return false;
            if (acc.Balance < amount) return false;
            acc.Balance -= amount;
            acc.WithdrawnToday += amount;
            return true;
        }

        public void BlockCard(int userId)
        {
            if (_accounts.TryGetValue(userId, out var acc))
                acc.IsBlocked = true;
            Console.WriteLine($"[BANK] Card for account {userId} has been blocked.");
        }

        public int GetDailyLimit(int userId) =>
            _accounts.TryGetValue(userId, out var acc) ? acc.DailyLimit : 0;

        public int GetAmountWithdrawnToday(int userId) =>
            _accounts.TryGetValue(userId, out var acc) ? acc.WithdrawnToday : 0;

        public void LogTransaction(int userId, int amount, bool success, string reason)
        {
            // In production: write to audit DB/log stream
            string status = success ? "SUCCESS" : "FAILED";
            Console.WriteLine($"[BANK LOG] User={userId} Amount=₹{amount} Status={status} Reason={reason}");
        }
    }
}
namespace _25_Q3_ATMmachine
{
    // Proxy pattern:
    // Sits between ATM and RealBankService. Enforces:
    //   1. Session authentication guard (is user logged in?)
    //   2. Daily withdrawal limit check
    //   3. Transaction logging for every call
    //   4. Caches daily limit per session (avoids repeated bank calls)
    public class BankServiceProxy : IBankService
    {
        private readonly IBankService _realBank;
        private bool _isSessionActive = false;
        private int _activeUserId = -1;

        // Cache daily limit per session to avoid repeated network calls
        private readonly Dictionary<int, int> _dailyLimitCache = new();

        public BankServiceProxy(IBankService realBank)
        {
            _realBank = realBank;
        }

        // Called by ATMService when PIN is accepted
        public void StartSession(int userId)
        {
            _isSessionActive = true;
            _activeUserId = userId;
            // Pre-fetch and cache the daily limit once per session
            _dailyLimitCache[userId] = _realBank.GetDailyLimit(userId);
            Console.WriteLine($"[PROXY] Session started for user {userId}.");
        }

        // Called on cancel or after transaction completes
        public void EndSession()
        {
            Console.WriteLine($"[PROXY] Session ended for user {_activeUserId}.");
            _isSessionActive = false;
            _activeUserId = -1;
        }

        public bool ValidatePin(int userId, int pin)
        {
            // PIN validation happens before session — no auth guard here
            bool result = _realBank.ValidatePin(userId, pin);
            _realBank.LogTransaction(userId, 0, result, result ? "PIN validated" : "Wrong PIN");
            if (result) StartSession(userId);
            return result;
        }

        public int GetBalance(int userId)
        {
            if (!GuardSession(userId)) return 0;
            int balance = _realBank.GetBalance(userId);
            _realBank.LogTransaction(userId, 0, true, $"Balance checked: ₹{balance}");
            return balance;
        }

        public bool Debit(int userId, int amount)
        {
            if (!GuardSession(userId)) return false;

            // Daily limit check (uses cached limit)
            int dailyLimit = _dailyLimitCache.TryGetValue(userId, out int lim) ? lim : 0;
            int withdrawnToday = _realBank.GetAmountWithdrawnToday(userId);

            if (withdrawnToday + amount > dailyLimit)
            {
                Console.WriteLine($"[PROXY] Debit blocked: daily limit ₹{dailyLimit} would be exceeded (already withdrawn ₹{withdrawnToday}).");
                _realBank.LogTransaction(userId, amount, false, "Daily limit exceeded");
                return false;
            }

            bool success = _realBank.Debit(userId, amount);
            string reason = success ? "Debit successful" : "Insufficient funds";
            _realBank.LogTransaction(userId, amount, success, reason);

            if (success) EndSession();   // auto-end session after successful withdrawal
            return success;
        }

        public void BlockCard(int userId)
        {
            _realBank.BlockCard(userId);
            _realBank.LogTransaction(userId, 0, false, "Card blocked after 3 wrong PINs");
            EndSession();
        }

        public int GetDailyLimit(int userId) =>
            _dailyLimitCache.TryGetValue(userId, out int lim) ? lim : _realBank.GetDailyLimit(userId);

        public int GetAmountWithdrawnToday(int userId) =>
            _realBank.GetAmountWithdrawnToday(userId);

        public void LogTransaction(int userId, int amount, bool success, string reason) =>
            _realBank.LogTransaction(userId, amount, success, reason);

        // ── Guard ────────────────────────────────────────────────────────────────
        private bool GuardSession(int userId)
        {
            if (!_isSessionActive || _activeUserId != userId)
            {
                Console.WriteLine($"[PROXY] Access denied: no active session for user {userId}.");
                return false;
            }
            return true;
        }
    }
}
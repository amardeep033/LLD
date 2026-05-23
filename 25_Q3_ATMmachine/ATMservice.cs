namespace _25_Q3_ATMmachine
{
    public class ATMService
    {
        public int Id { get; }
        public ATMStatus Status => _state.Status;

        private IATMState _state;

        public IBankService Bank { get; }
        public int ActiveUserId { get; set; } = -1;

        private readonly int _timeoutSeconds;
        private DateTime _lastActionTime = DateTime.MinValue;

        public ATMService(int id, IBankService bank, int timeoutSeconds = 60)
        {
            Id = id;
            Bank = bank;
            _timeoutSeconds = timeoutSeconds;
            _state = new StatusIdle();
        }

        public void ActionInsertCard(int userId)
        {
            CheckSessionTimeout();
            ActiveUserId = userId;
            _state.ActionInsertCard(this);
            RecordAction();
        }
        public void ActionEnterPin(int pin)
        {
            CheckSessionTimeout();
            _state.ActionEnterPin(this, pin);
            RecordAction();
        }
        public void ActionCheckBalance()
        {
            CheckSessionTimeout();
            _state.ActionCheckBalance(this, Bank);
            RecordAction();
        }
        public void ActionDispenseCash(ATMInventory inventory, int amount)
        {
            CheckSessionTimeout();
            _state.ActionDispenseCash(this, inventory, Bank, amount);
            RecordAction();
        }
        public void ActionCancel() {
            CheckSessionTimeout();
            _state.ActionCancel(this);
            RecordAction();
        }
        public void SetState(IATMState newState)
        {
            _state = newState;
            if (newState is StatusIdle or StatusOutOfCash)
                _lastActionTime = DateTime.MinValue;
        }

        private void CheckSessionTimeout()
        {
            if (_state is StatusIdle || _lastActionTime == DateTime.MinValue) return;

            double idleSeconds = (DateTime.Now - _lastActionTime).TotalSeconds;
            if (idleSeconds >= _timeoutSeconds)
            {
                Console.WriteLine($"[ATM {Id}] Session expired ({(int)idleSeconds}s idle, limit {_timeoutSeconds}s). Ejecting card.");

                if (Bank is BankServiceProxy proxy)
                    proxy.EndSession();

                _state = new StatusIdle();
                ActiveUserId = -1;
                _lastActionTime = DateTime.MinValue;
            }
        }

        private void RecordAction() => _lastActionTime = DateTime.Now;

        public void PrintStatus() =>
            Console.WriteLine($"[ATM {Id}] Status: {Status}");
    }
}

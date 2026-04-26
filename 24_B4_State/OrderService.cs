// GOOD: Order is a thin context — it holds a state object and delegates everything.
// Zero if/else-if chains. Zero knowledge of what each state does.
// Adding a new status = add a new state class, touch nothing here.
namespace StatePattern
{
    public class Order
    {
        public int Id { get; private set; }
        public OrderStatus Status => _state.Status;

        private IOrderState _state;

        public Order(int id)
        {
            Id = id;
            _state = new PendingState();
        }

        // All four actions purely delegate — Order has no opinion about validity
        public void ActionConfirm() => _state.ActionConfirm(this);
        public void ActionShip() => _state.ActionShip(this);
        public void ActionDeliver() => _state.ActionDeliver(this);
        public void ActionCancel() => _state.ActionCancel(this);

        // Called only by state objects to hand off to the next state
        public void SetState(IOrderState newState)
        {
            _state = newState;
        }

        public void PrintStatus() =>
            Console.WriteLine($"[Order {Id}] Status: {Status}");
    }
}
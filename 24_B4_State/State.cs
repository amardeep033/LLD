// Each state class owns exactly the logic for its own status.
// It knows what's valid, what isn't, and which state comes next.
// No other class needs to change when a new state is added.

//State containing all actions

namespace StatePattern
{
    public class PendingState : IOrderState
    {
        public OrderStatus Status => OrderStatus.StatePending;

        public void ActionConfirm(Order order)
        {
            Console.WriteLine($"  Payment charged for order {order.Id}.");
            order.SetState(new ConfirmedState());
        }

        public void ActionShip(Order order) =>
            Console.WriteLine($"  [ERROR] Order {order.Id} is Pending — confirm it first.");

        public void ActionDeliver(Order order) =>
            Console.WriteLine($"  [ERROR] Order {order.Id} is Pending — confirm and ship it first.");

        public void ActionCancel(Order order)
        {
            Console.WriteLine($"  Order {order.Id} cancelled before payment.");
            order.SetState(new CancelledState());
        }
    }

    //-------------

    public class ConfirmedState : IOrderState
    {
        public OrderStatus Status => OrderStatus.StateConfirmed;

        public void ActionConfirm(Order order) =>
            Console.WriteLine($"  [ERROR] Order {order.Id} is Confirmed — already confirmed.");

        public void ActionShip(Order order)
        {
            Console.WriteLine($"  Tracking number assigned for order {order.Id}.");
            order.SetState(new ShippedState());
        }

        public void ActionDeliver(Order order) =>
            Console.WriteLine($"  [ERROR] Order {order.Id} is Confirmed — ship it first.");

        public void ActionCancel(Order order)
        {
            Console.WriteLine($"  Order {order.Id} cancelled — refund initiated.");
            order.SetState(new CancelledState());
        }
    }

    //-------------

    public class ShippedState : IOrderState
    {
        public OrderStatus Status => OrderStatus.StateShipped;

        public void ActionConfirm(Order order) =>
            Console.WriteLine($"  [ERROR] Order {order.Id} is Shipped — already past confirmation.");

        public void ActionShip(Order order) =>
            Console.WriteLine($"  [ERROR] Order {order.Id} is Shipped — already shipped.");

        public void ActionDeliver(Order order)
        {
            Console.WriteLine($"  Customer notified. Order {order.Id} delivered.");
            order.SetState(new DeliveredState());
        }

        public void ActionCancel(Order order) =>
            Console.WriteLine($"  [ERROR] Order {order.Id} is Shipped — can't cancel, already in transit.");
    }

    //-------------

    public class DeliveredState : IOrderState
    {
        public OrderStatus Status => OrderStatus.StateDelivered;

        // Terminal state — nothing is valid
        public void ActionConfirm(Order order) => Invalid(order);
        public void ActionShip(Order order) => Invalid(order);
        public void ActionDeliver(Order order) => Invalid(order);
        public void ActionCancel(Order order) => Invalid(order);

        private void Invalid(Order order) =>
            Console.WriteLine($"  [ERROR] Order {order.Id} is Delivered — no further actions.");
    }

    //-------------

    public class CancelledState : IOrderState
    {
        public OrderStatus Status => OrderStatus.StateCancelled;

        // Terminal state — nothing is valid
        public void ActionConfirm(Order order) => Invalid(order);
        public void ActionShip(Order order) => Invalid(order);
        public void ActionDeliver(Order order) => Invalid(order);
        public void ActionCancel(Order order) => Invalid(order);

        private void Invalid(Order order) =>
            Console.WriteLine($"  [ERROR] Order {order.Id} is Cancelled — no further actions.");
    }
}
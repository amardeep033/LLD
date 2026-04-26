// BAD: Order owns all state logic directly.
// Every method is a wall of if/else-if — one branch per status.
// Adding a new status means reopening every single method.
namespace StatePattern
{
    public class BadOrder
    {
        public int Id { get; private set; }
        public OrderStatus Status { get; private set; }

        public BadOrder(int id)
        {
            Id = id;
            Status = OrderStatus.StatePending;
        }

        //action containing all states

        public void ActionConfirm()
        {
            // if/else-if is REQUIRED here — branches are mutually exclusive
            if (Status == OrderStatus.StatePending)
            {
                Status = OrderStatus.StateConfirmed;
                Console.WriteLine($"  Payment charged for order {Id}.");
            }
            else if (Status == OrderStatus.StateConfirmed)
                Console.WriteLine($"  [ERROR] Order {Id} is Confirmed — already confirmed.");
            else if (Status == OrderStatus.StateShipped)
                Console.WriteLine($"  [ERROR] Order {Id} is Shipped — already past confirmation.");
            else if (Status == OrderStatus.StateDelivered)
                Console.WriteLine($"  [ERROR] Order {Id} is Delivered — no further actions.");
            else if (Status == OrderStatus.StateCancelled)
                Console.WriteLine($"  [ERROR] Order {Id} is Cancelled — no further actions.");
        }

        //------------

        public void ActionShip()
        {
            // Same if/else-if wall repeated for every method.
            if (Status == OrderStatus.StateConfirmed)
            {
                Status = OrderStatus.StateShipped;
                Console.WriteLine($"  Tracking number assigned for order {Id}.");
            }
            else if (Status == OrderStatus.StatePending)
                Console.WriteLine($"  [ERROR] Order {Id} is Pending — confirm it first.");
            else if (Status == OrderStatus.StateShipped)
                Console.WriteLine($"  [ERROR] Order {Id} is Shipped — already shipped.");
            else if (Status == OrderStatus.StateDelivered)
                Console.WriteLine($"  [ERROR] Order {Id} is Delivered — no further actions.");
            else if (Status == OrderStatus.StateCancelled)
                Console.WriteLine($"  [ERROR] Order {Id} is Cancelled — no further actions.");
        }

        //------------

        public void ActionDeliver()
        {
            if (Status == OrderStatus.StateShipped)
            {
                Status = OrderStatus.StateDelivered;
                Console.WriteLine($"  Customer notified. Order {Id} delivered.");
            }
            else if (Status == OrderStatus.StatePending)
                Console.WriteLine($"  [ERROR] Order {Id} is Pending — confirm and ship it first.");
            else if (Status == OrderStatus.StateConfirmed)
                Console.WriteLine($"  [ERROR] Order {Id} is Confirmed — ship it first.");
            else if (Status == OrderStatus.StateDelivered)
                Console.WriteLine($"  [ERROR] Order {Id} is Delivered — no further actions.");
            else if (Status == OrderStatus.StateCancelled)
                Console.WriteLine($"  [ERROR] Order {Id} is Cancelled — no further actions.");
        }

        //--------------

        public void ActionCancel()
        {
            if (Status == OrderStatus.StateDelivered)
                Console.WriteLine($"  [ERROR] Order {Id} is Delivered — no further actions.");
            else if (Status == OrderStatus.StateCancelled)
                Console.WriteLine($"  [ERROR] Order {Id} is already Cancelled.");
            else if (Status == OrderStatus.StateShipped)
                Console.WriteLine($"  [ERROR] Order {Id} is Shipped — can't cancel, already in transit.");
            else
            {
                Status = OrderStatus.StateCancelled;
                Console.WriteLine($"  Order {Id} cancelled.");
            }
        }

        //--------------

        public void PrintStatus() =>
            Console.WriteLine($"[Order {Id}] Status: {Status}");
    }
}
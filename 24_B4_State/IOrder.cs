namespace StatePattern
{
    public interface IOrderState
    {
        OrderStatus Status { get; }
        void ActionConfirm(Order order);
        void ActionShip(Order order);
        void ActionDeliver(Order order);
        void ActionCancel(Order order);
    }
}
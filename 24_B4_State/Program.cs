//state pattern is used when different transitions are possible for an object based on its current state. It allows an object to alter its behavior when its internal state changes.
//example: order service with functions like PlaceOrder(), ConfirmOrder(), ShipOrder(), DeliverOrder(), CancelOrder().
//The transittions are as follows: pending -> confirmed -> shipped -> delivered and cancelled (Can't be cancelled after being delivered)

//there are two things: state and actions
//state: pending, confirmed, shipped, delivered, cancelled
//actions: confirm, ship, deliver, cancel

// Adding a new STATE (e.g. ReturnRequestedState):
//   if-else: hard to add state
//   State pattern: easy to add state

// Adding a new ACTION (e.g. ReturnRequested()):
//   if-else: easy to add action
//   State pattern: hard to add action

//if else-if — action owns the states
//State pattern — state owns the actions

//For an order lifecycle — you defined the actions on day one: Confirm, Ship, Deliver, Cancel. Those four actions are stable forever. 
//What keeps changing over months of product development is states: OnHold, ReturnRequested, RefundPending, PartiallyShipped.

using StatePattern;

var order = new BadOrder(101);
order.PrintStatus();
order.ActionConfirm();
order.PrintStatus();
order.ActionShip();
order.PrintStatus();
order.ActionDeliver();
order.PrintStatus();
order.ActionCancel();
Console.WriteLine();

var order2 = new Order(101);
order2.PrintStatus();
order2.ActionConfirm();
order2.PrintStatus();
order2.ActionShip();
order2.PrintStatus();
order2.ActionDeliver();
order2.PrintStatus();
order2.ActionCancel();
Console.WriteLine();
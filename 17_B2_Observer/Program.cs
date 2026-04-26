//Observer Pattern is used to create a subscription mechanism to allow multiple objects to listen to and react to events or changes in another object.
//Basically notififying an object when there is a change in another object.
//Polling (observer keeps on checking) vs Pushing (observable has notify method)
//Example: After placing an order, notify email, sms, and inventory system.
//In this example, PlaceOrder is observable and EmailService, SmsService are observers.
//Observers subscribe to the observable - pub sub model.

using _17_B2_Observer;

BadOrderService badOrderService = new BadOrderService(new BadEmailService(), new BadSmsService());
badOrderService.PlaceOrder("Order details");

Console.WriteLine("\n------\n");

GoodOrderService orderService = new GoodOrderService();
orderService.Subscribe(new GoodEmailService());
orderService.Subscribe(new GoodSmsService());
orderService.PlaceOrder("Order details");
//adding a new obeserver is easy - just implement the IObserver interface and subscribe to the observable. No need to change the observable code. This is the main advantage of the observer pattern - it promotes loose coupling between the observable and observers.
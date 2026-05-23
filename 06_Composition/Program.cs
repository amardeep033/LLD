//Composition is when a class is made up more than one class. It is a "has a" relationship. For example, a car has an engine, wheels, and a body.
//Composition is a way to create complex objects by combining simpler objects. It allows for code reuse and can make code easier to maintain.
//Use when want to combine diffrent behaviors or functionalities into a single class, without creating a complex inheritance hierarchy.
//places where inheritance is not correct - like order and payment -- > order has a payment, but payment is not an order.
//composition can be both loose and tight coupling, depending on how it is implemented. Composition + DI = Loose Couplineg, Composition without DI = Tight Coupling.

//Interface and Class both are composition (✔ Composition happens when a class contains objects (fields) of other classes or interfaces). 
//Using an interface type for the field is actually **better** composition because it's loosely coupled.
//But this ain't composition: public class EmailSender : INotification, ILogger -> same class implements both -- whereas in composition -- class uses other objects to get things done
//Note: multiple interface allowed in csharp but only single class inheritance allowed in csharp.
//public class EmailSender : INotification, ILogger --> not composition
//inheritance is-a | compisition has-a | interface can-do (defines contract bw diff unrelated classes)

// public class OrderService
// {
       // readonly because Because dependencies injected via constructor should not change.
//     private readonly EmailSender _email;   // composition ---> made up of these two classes
//     private readonly RetryPolicy _retry;   // composition ---> its just a field declaration, provided from outside, and intialized in the constructor.

//fragile base class -- any change in parent impacting child -- prefer composition over inheritance

//This is example of aggregation -- When people say "prefer composition over inheritance" they mean the broad sense — use has-a, avoid is-a. 
//They don't strictly mean UML composition.
//OrderService holds onto _processor and _logger for its entire lifetime -- Aggregation -- stored as field
//if use and forget then association -- that is not stored as field

using _6_Composition;

class Program
{
    static void Main()
    {
        IPaymentProcessor processor = new StripePaymentProcessor();  // swap to PayPal anytime
        ILogger logger = new ConsoleLogger();

        // Injecting dependencies into OrderService
        OrderService orderService = new OrderService(processor, logger);

        orderService.PlaceOrder("Mechanical Keyboard", 149.99m);
    }
}
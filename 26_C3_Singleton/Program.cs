using Microsoft.Extensions.DependencyInjection;

//singleton pattern is like a global variable -- single instance of a class that can be accessed globally
//it is used to control access to a resource that is shared across the entire application
//it is also used to implement a global state that can be accessed and modified by multiple parts of the application
//example: a logging class that is used to log messages from different parts of the application, configuration manager that is used to manage application settings, database connection pool that is used to manage database connections

//there are three things: eager/lazy || thread safety || how many instances are created
//1 bad logger implementation -- everyone creates their own instance and pass, tightly coupled to the classes that use it(impl in badlogger.cs)
//2 bad singleton -- creation as a public method -- not thread safe(not impl)
//3 Singleton -- creation as a private constructor(static is imp) -- thread safe but not lazy(impl in logger.cs)
//4 Better singleton -- making use of DI container -- allows us to manage lifecycle(singleton, scoped, transient) (impl in goodlogger.cs) -- this is already lazy by DI container
//5 lazy singleton -- instance is created only when first accessed (on-demand), not at class load time. Lazy<T> handles thread-safety internally using double-checked locking under the hood. (impl in lazylogger.cs)

//1----------------------------------------------------------------------------------------------------
Console.WriteLine("---- Before Singleton Implementation ----");

BadPaymentService bad_payment = new BadPaymentService();
BadOrderService bad_order = new BadOrderService();
bad_payment.ProcessPayment();
bad_order.CreateOrder();


//3----------------------------------------------------------------------------------------------------

Console.WriteLine("---- After Singleton Implementation ----");

bool isLazyLoggerCreated = LazyLogger.IsLazyLoggerCreated;
Console.WriteLine($">>>>Is Lazy Logger Created: {isLazyLoggerCreated}");

PaymentService payment = new PaymentService(); //eager logger created here when class is accessed
OrderService order = new OrderService();
payment.ProcessPayment(); //inside this fn : we call lazylogger.instance -- so must be created
order.CreateOrder();

bool isLazyLoggerCreated2 = LazyLogger.IsLazyLoggerCreated;
Console.WriteLine($">>>>Is Lazy Logger Created2: {isLazyLoggerCreated2}");

//3.5----------------
Console.WriteLine("---- After Singleton Implementation using lazy logger----");
PaymentService payment2 = new PaymentService();
OrderService order2 = new OrderService();

payment2.ProcessPayment();
order2.CreateOrder();

//4----------------------------------------------------------------------------------------------------

Console.WriteLine("---- After Good Singleton Implementation ----");

// Console.WriteLine($"Logger created before resolve? {GoodLazyLogger.IsCreated}");

//DI Container - maintains the lifecycle of the services and their dependencies - provided by Microsoft.Extensions.DependencyInjection
var services = new ServiceCollection();

//here we are telling that whenever an instance of ILoggerService is requested, 'specified' instance of GoodLoggerService will be injected to the constructor of the class that requires it.

services.AddSingleton<ILoggerService, GoodLoggerService>(); //this is already lazy by di container
// services.AddScoped<ILoggerService, GoodLoggerService>();
// services.AddTransient<ILoggerService, GoodLoggerService>();

//here we are registering the GoodPaymentService and GoodOrderService as transient services -- create instance every time
services.AddTransient<GoodPaymentService>(); //try AddSingleton and AddScoped
services.AddTransient<GoodOrderService>(); //try AddSingleton and AddScoped

//lock the registration of services and build the service provider -- after this line no new registration of services can be added to the container
var provider = services.BuildServiceProvider();

////SCOPE0 -- root scope
//its like creating objects using new keyword but here we are asking the DI container to create the objects for us and inject the dependencies automatically
var good_payment = provider.GetRequiredService<GoodPaymentService>();
var good_order = provider.GetRequiredService<GoodOrderService>();

//normal function call
good_payment.ProcessPayment();
good_order.CreateOrder();

////SCOPE1
using (var scope = provider.CreateScope())
{
    var p = scope.ServiceProvider.GetRequiredService<GoodPaymentService>();
    var o = scope.ServiceProvider.GetRequiredService<GoodOrderService>();

    p.ProcessPayment();
    o.CreateOrder();
}
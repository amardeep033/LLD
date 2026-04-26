//Builder Pattern is used when you need to construct a complex object step by step.
//The same construction process can create different representations.
//Problem: Constructor with 10 parameters - telescoping constructor anti-pattern - hard to read, easy to mess up order
//new Order("John", "NYC", true, false, null, 10, "SAVE10", true, 3, "credit") - what is true? what is false?
//Solution: Builder separates construction from representation - you build what you need, skip what you don't
//Fluent interface: each method returns the builder itself (this) - allows method chaining
//Director (optional): encapsulates common build recipes - e.g. BuildStandardOrder(), BuildGuestOrder()
//Builder vs Decorator: Builder constructs a NEW object step by step, final type at end (.Build())
//                      Decorator wraps an EXISTING object, same interface throughout, no final step
//Builder vs Fluent Interface: Fluent is just the syntax (method chaining) - Builder is the pattern
//                             Builder uses fluent interface but fluent interface is not always builder
//When to use: complex object with many optional parameters, same object different configurations
//Real world: SQL query builders, HttpRequestMessage, EF Core query building, test data builders (arrange phase)

using BuilderPattern;

// BAD: telescoping constructor - which bool is gift wrap? which is express?
BadOrder badOrder = new BadOrder("John", "NYC", true, false, null, 10, "SAVE10");
// try reading this 6 months later - you have no idea what true/false means without going to constructor

Console.WriteLine("\n------\n");

// GOOD: builder - reads like english, skip what you don't need
GoodOrder order = new OrderBuilder()
    .ForCustomer("John")
    .DeliverTo("NYC")
    .WithExpressShipping()
    .WithDiscount("SAVE10", 10)
    .WithGiftWrap()
    .Build();
// clear, readable, impossible to mix up parameter order
// adding new optional field = new builder method, zero changes to existing code
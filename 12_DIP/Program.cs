// DIP — Dependency Inversion Principle

//Imagine we have two types of class - Order and Logging 
//Order can make use of logging, but logging is used at other places too
//If we create log obj inside order -- tight couple -- now what if we want to change one type of logging with other -- need to change order class too

// High level modules should not depend on low level modules.
// Both should depend on abstractions.

//DI is one pattern that satisfies DIP — you inject the abstraction from outside instead of creating it inside

using _12_DIP;

BadOrderService bo = new BadOrderService();
bo.PlaceOrder();

ILoggerService logger = new GoodLoggerService();
GoodOrderService go = new GoodOrderService(logger);
go.PlaceOrder();

ILoggerService logger2 = new NewLoggerService();
GoodOrderService go2 = new GoodOrderService(logger2);
go2.PlaceOrder();
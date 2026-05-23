//lets say i have two types of class - notification,retry and email,sms
//now here i want to send email and sms notification and retry for both of them
//here i cant say that notification is a parent class and email and sms are child class and retry will be method in notification -- bad design
//as retry can be for other things too like other kind of notification - also all notification will again have sms, email and retry method which is not good design -- tightly coupled
//also we need to create email and sms class inside notification class which is not good design -- tightly coupled

//“is-a AND shares common structure/behavior” for inheritance and “has-a AND uses” for composition. Inheritance is a strong relationship where the child class is a type of the parent class, while composition is a weaker relationship where one class contains or uses another class to achieve its functionality. Inheritance promotes code reuse and can lead to tight coupling, while composition promotes flexibility and loose coupling.

using _5_Coupling;

BadPlaceOrder badPlaceOrder = new BadPlaceOrder();
//need to send email to place order 
badPlaceOrder.PlaceOrder("Laptop", 1, "user@example.com");

//better design is to use interface and dependency injection to decouple the classes
GoodPlaceOrder goodPlaceOrder = new GoodPlaceOrder(new GoodEmailSender());
goodPlaceOrder.PlaceOrder("Laptop", 1, "user@example.com");

//without even touching the place order class we can change the notification type to sms by just changing the implementation of the interface -- loosely coupled
GoodPlaceOrder goodPlaceOrder2 = new GoodPlaceOrder(new GoodSmsSender());
goodPlaceOrder2.PlaceOrder("Laptop", 1, "user@example.com");

//in csharp, a child can have only one parent class but can implement multiple interfaces -- this is called multiple inheritance through interfaces
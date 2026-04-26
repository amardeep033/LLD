//Decorator pattern is when you want to add new functionality to an existing object without changing its structure. 
//It is a structural design pattern that allows behavior to be added to an individual object, either statically or dynamically, without affecting the behavior of other objects from the same class.
//No if else as it violates ocp and srp - no inheritance as class explosion for every combination of features
//It is slower but very minimal - but advantage is much more flexible and maintainable code - no merge conflicts as no change in existing code - just a new class
//Flags approach: One class does everything vs Decorator approach: Each class does ONE thing and composes
//Testing is a nightmare with flags approach as you have to test every combination of features as existing can break with new features - with decorator approach you can test each feature independently and then test the composition of features separately
//client.get(url).header(...).query(...).send() - each method returns a new object with the added functionality - this is a common example of the decorator pattern in action - builder pattern??
//All function in chain return type is same except send which is the final action that triggers the request - this allows for a fluent interface and easy composition of features without changing the underlying client class
//The decorator and the component it wraps must share the same interface. That's what makes them interchangeable and stackable - var coffee = new MilkDecorator(new SugarDecorator(new BasicCoffee()));
//In decorator pattern, the order of decorators can matter
//builder pattern vs fluent interface vs decorator pattern

BadHttpClient badClient = new BadHttpClient(
    enableLogging: true,
    enableAuth: true,
    enableRetry: false
    //adding more features would require: constructor changes, class change and caller change - violates ocp and srp
);
badClient.Send("https://api.example.com/orders");

Console.WriteLine("\n--- Decorator Pattern ---\n");

//creation pattern run in to out -- here we are just saying we want a client with logging, auth and retry - we don't care about the order of creation - we just want the features - this is the beauty of the decorator pattern - we can compose features in any order without changing the underlying classes
//each constructor takes an IHttpClient and returns an IHttpClient - this allows for easy composition of features without changing the underlying client class - we can add new features by just creating new decorators without changing existing code - this is the open/closed principle in action
IHttpClient client = new RetryDecorator(
    new AuthDecorator(
        new LoggingDecorator(
            new HttpClient()
        )
    )
);

//what if we want log inside retry and auth? - Decorators don’t talk to each other — they communicate through the request flowing between them.
//retry will call .send multiple time - so log will be captured for each retry - auth will add token for each retry - this is the beauty of the decorator pattern 
//let decorators collaborate via composition + shared context

//call order runs out to in
client.Send("https://api.example.com/orders");

// _inner.Send(url) is the pivot point in every decorator
// code before it = before hook  (add header, start timer, log request)
// code after it  = after hook   (log response, record duration, handle errors)
// this is exactly how ASP.NET middleware pipeline works — same mental model
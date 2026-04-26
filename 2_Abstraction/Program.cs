using _2_Abstraction;

//without abstraction, the client code is responsible for calling all the methods in the correct order. This can lead to errors if the client forgets to call a method or calls them in the wrong order.
BadEmail badEmail = new BadEmail();
badEmail.Authentication();
badEmail.Connect();
badEmail.SendEmail();
badEmail.Disconnect();

//with abstraction, the client code only needs to call the SendEmail method, which takes care of calling the other methods in the correct order. This reduces the chances of errors and makes the code easier to use.
GoodEmail goodEmail = new GoodEmail();
goodEmail.SendEmail();

//abstraction hide unnecessary details from the client code, making it easier to use and understand
//less decision to make for the client code, which can lead to fewer errors and a better user experience
//if any change in lets say parameter, only one place to change, which is the method itself, rather than changing all the places where the method is called
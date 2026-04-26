//Factory is having all object creation logic at one place
//Caller should only pass type - it should not decide WHICH class to instantiate.
//Think from the perspective of caller -- where also different types can be there
//Lets say we have a logger class and based on type passed by user -- caller wants to create the object -- and this logger is used at many places
//Now say we are introducing new log type -- so we need to handle it at every caller place

//Factory will make use of if-else -- this will violate OCP -- but atleast all creation logic will be at one place
//For different sets of arsg -- we should make use of context
//real world example : HttpContext, DbContextOptions, ActionContext, RequestContext

using _14_C1_Factory;

// ----------BAD CODE------------

string type = "push";

INotification notification;

if (type == "email")
{
    notification = new EmailNotification("user@gmail.com"); //client should have detail about concrete classes, same logic will be duplicated everywhere and ocp violation
}
else if (type == "sms")
{
    notification = new SmsNotification("9999999999");
}
else if (type == "push")
{
    notification = new PushNotification("device123", "appABC");
}
else
{
    throw new Exception("Invalid notification type");
}

notification.Send("Order placed!");


// ----------GOOD CODE------------

NotificationContext ctx = new NotificationContext
{
    Type = "push",
    DeviceId = "device123",
    AppId = "appABC"
};

//the Factory can return an interface type, so the caller never even knows the concrete class
INotification notification2 = NotificationFactory.Create(ctx);

notification2.Send("Order placed!");
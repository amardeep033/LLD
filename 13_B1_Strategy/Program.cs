//Strategy Pattern - used to pass different algo to object -- helps to not violate OCP 
//Also if multiple people are working - they can work and test independently
//Strategy pattern allows selecting an algorithm at runtime by encapsulating each algorithm in separate classes implementing a common interface.

using _13_B1_Strategy_Pattern;

BadPaymentService bps = new BadPaymentService();
bps.ProcessPayment("creditcard", 100);
bps.ProcessPayment("upi", 50);

IGoodPaymentStrategy strategy1 = new CreditCardPayment();
IGoodPaymentStrategy strategy2 = new UPIPayment();

GoodPaymentService gps1 = new GoodPaymentService(strategy1);
gps1.ProcessPayment(100);
GoodPaymentService gps2 = new GoodPaymentService(strategy2);
gps2.ProcessPayment(50);
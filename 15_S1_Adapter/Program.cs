//Adapter Design Pattern is a structural design pattern that allows objects with incompatible interfaces to work together. 
//It acts as a bridge between two incompatible interfaces -- such as different fn name, signature, datatype or constructor.
//The adapter pattern is particularly useful when integrating third-party libraries or legacy systems into a new application.

using _15_S1_Adapter;

BadOldStripe bad_old_stripe = new BadOldStripe("stripe_api_key");
BadPaymentService bad_old_pay_serv = new BadPaymentService(bad_old_stripe);
bad_old_pay_serv.ProcessPayment(100);

BadNewJuspay bad_new_juspay = new BadNewJuspay("merchant_id", "secret");
//Payment service needs to be updated as old has charge method and new has makepayment method
UpdatedBadPaymentService bad_new_pay_serv = new UpdatedBadPaymentService(bad_new_juspay);
bad_new_pay_serv.ProcessPayment(100);


IPaymentGateway good_old_stripe = new GoodOldStripe("stripe_api_key");
GoodPaymentService good_old_pay_serv = new GoodPaymentService(good_old_stripe);
good_old_pay_serv.ProcessPayment(100);

IPaymentGateway good_new_juspay = new GoodNewJuspay("merchant_id", "secret");
//here method is same for both old and new payment services as they both implement the same interface, so we can use the same payment service for both
GoodPaymentService good_new_pay_serv = new GoodPaymentService(good_new_juspay);
good_new_pay_serv.ProcessPayment(100);
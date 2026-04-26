//Facade Pattern is used to provide a simplified interface to a complex subsystem.
//Instead of the client knowing about multiple services, it talks to one Facade.
//Problem: Controller/client tightly coupled to InventoryService, PaymentService, ShippingService.
//Solution: OrderFacade hides the orchestration. Client just calls PlaceOrder().
//Real benefit: Multiple callers (REST controller, background job, admin panel) all share
//the same Facade - zero duplication of orchestration logic across callers.

// “I’ll introduce a Facade so clients/controllers don’t directly coordinate multiple services. It reduces coupling and keeps orchestration in one place.”
// 1. E-commerce Checkout System
// Components: ------
// CartService
// PaymentService
// InventoryService
// CouponService
// NotificationService
// Use: ------
// CheckoutFacade.PlaceOrder()

using _18_B2_Facade;

// Bad: controller manually orchestrates every subsystem
// Any other caller (background job, admin panel) must duplicate ALL of this logic
BadOrderController badController = new BadOrderController(
    new InventoryService(),
    new PaymentService(),
    new ShippingService()
);
badController.PlaceOrder("iPhone 15", 2, "tok_visa", 1999.99m, "123 MG Road, Bangalore");

Console.WriteLine("\n------\n");

// Good: one Facade, three completely different callers - zero duplication
// Adding LoyaltyService tomorrow? Change only Facade. All 3 callers get it for free.
GoodOrderFacade facade = new GoodOrderFacade(
    new InventoryService(),
    new PaymentService(),
    new ShippingService()
);

GoodOrderController goodController = new GoodOrderController(facade);
goodController.PlaceOrder("iPhone 15", 2, "tok_visa", 1999.99m, "123 MG Road, Bangalore");

Console.WriteLine();

OrderBackgroundJob backgroundJob = new OrderBackgroundJob(facade);
backgroundJob.RetryFailedOrder("iPhone 15", 2, "tok_visa", 1999.99m, "123 MG Road, Bangalore");

Console.WriteLine();

AdminController adminController = new AdminController(facade);
adminController.ManualOrder("iPhone 15", 2, "tok_visa", 1999.99m, "123 MG Road, Bangalore");
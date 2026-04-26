# Backend Architecture + Facade Pattern Summary

## 1. Core Backend Flow

```text
Client / Frontend
↓
Controller (Presentation)
↓
Service / Application Layer
↓
Domain Layer
↓
Data / Infrastructure Layer
```

---

## 2. Responsibilities of Each Layer

### Controller
Handles HTTP/API concerns.
- Routing
- Request parsing
- Validation (basic)
- Return status codes / responses
- Calls service layer

**Keep thin.**

### Service Layer (Application Layer)
Coordinates use-cases.
Examples:
- Register user
n- Place order
- Process payout

Responsibilities:
- Workflow orchestration
- Calling repositories / external systems
- Transactions

### Domain Layer
Contains business rules.
Examples:
- Cannot withdraw below minimum balance
- Order cannot be cancelled after shipping
- Wallet cannot go negative

Contains:
- Entities
- Value Objects
- Domain Services

### Data / Infrastructure Layer
Handles external systems.
- Database
- Redis
- Kafka
- Payment gateways
- Email providers

---

## 3. MVC vs Layers

MVC is usually a **presentation pattern**.

- Model
- View
- Controller

It can coexist with layered architecture.

```text
MVC (top/UI layer)
↓
Service Layer
↓
Domain
↓
Data Layer
```

---

## 4. Facade Pattern — Real Meaning

A **Facade** gives a **simple interface over a complex subsystem**.

Instead of consumer calling many services directly:

```text
Controller -> AuthService
           -> PaymentService
           -> InventoryService
           -> NotificationService
```

Use:

```text
Controller -> CheckoutFacade.PlaceOrder()
```

Facade hides orchestration complexity.

---

## 5. Important Truth: Service Can Act as Facade

Often in real systems:

```text
OrderService.PlaceOrder()
```

internally calls:
- PaymentService
- InventoryService
- NotificationService

Then **OrderService is effectively acting as a facade**.

Patterns are responsibilities, not mandatory class names.

---

## 6. When Facade Is Useful

Use when you have:

```text
Many collaborators + repeated orchestration + noisy consumers
```

Examples:
- Checkout system
- Ride booking
- Payment gateway aggregator
- Fintech onboarding flow
- Media upload pipeline

---

## 7. When Facade Is NOT Needed

Avoid when:
- Simple CRUD APIs
- Only one service involved
- Existing service already cleanly coordinates everything
- Adds useless wrapper layer

---

## 8. Testing Concepts

### Unit Test
Test one class in isolation.
Fake everything else.

```text
Test one box.
Fake everything outside the box.
```

### Integration Test
Real collaboration between components.
Examples:
- API + DB
- Service + Repository

### End-to-End Test
Full system flow.
Frontend -> API -> DB -> Queue -> Email

---

## 9. Mocking Explained

A **mock/fake** is a test double.

Instead of real payment gateway:

```text
Real PaymentService = charges money
Fake PaymentService = pretends success/failure
```

Useful for controlled scenarios:
- Success
- Timeout
- Exception

---

## 10. How Facade Helps Testing

Without facade:

```text
Controller depends on 5 services
```

Need many mocks in controller unit test.

With facade:

```text
Controller depends on CheckoutFacade only
```

Need one mock for controller test.

Then separate facade tests cover internal services.

---

## 11. Interview Answer Template for Facade

> I’d use a facade when multiple subsystems must work together and clients need a clean entry point. It reduces coupling and keeps orchestration in one place.

---

## 12. Senior-Level Nuance

If `OrderService.PlaceOrder()` already orchestrates dependencies, a separate facade may be unnecessary.

Use patterns pragmatically, not ceremonially.

---

## 13. Memory Tricks

| Layer | Think As |
|---|---|
| Controller | Door / Receptionist |
| Service | Coordinator / Manager |
| Domain | Brain / Rules |
| Data | Storage Worker |
| Facade | Front Desk for many departments |

---

## 14. Final Golden Rule

```text
Clean responsibilities > Pattern names
```
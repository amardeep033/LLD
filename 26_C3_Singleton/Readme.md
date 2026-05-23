# Singleton Pattern Interview Q&A (One-Liners)

## 1. What is Singleton Pattern?

Ensures only one instance of a class exists and provides global access to it.

---

## 2. Why use Singleton?

To share a common resource across the application efficiently.

---

## 3. Why constructor is private?

To prevent object creation using `new` outside the class.

---

## 4. Why instance variable is static?

Because the single instance must belong to the class itself.

---

## 5. What are common Singleton use cases?

Logger, config manager, cache manager, thread pool, feature flags.

---

## 6. What problem does Singleton solve?

Avoids unnecessary multiple object creation and inconsistent shared state.

---

## 7. Is basic Singleton thread-safe?

No, multiple threads can create multiple instances simultaneously.

---

## 8. How to make Singleton thread-safe?

Use locking, eager initialization, or `Lazy<T>`.

---

## 9. What is eager initialization?

Creating singleton instance at application startup.

---

## 10. What is lazy initialization?

Creating singleton instance only when first needed.

---

## 11. What is the best Singleton implementation in C#?

`Lazy<T>` or DI-managed singleton using `AddSingleton()`.

---

## 12. Difference between Singleton and static class?

Singleton is an object; static class is purely static behavior.

---

## 13. Can Singleton implement interfaces?

Yes, unlike static classes.

---

## 14. Can Singleton be inherited?

Yes, static classes cannot.

---

## 15. Why is Singleton better than static class?

Supports OOP concepts like interfaces, inheritance, and polymorphism.

---

## 16. What are drawbacks of Singleton?

Global state, tight coupling, and difficult testing.

---

## 17. Why is Singleton considered an anti-pattern sometimes?

Because excessive global shared state hurts maintainability and testability.

---

## 18. What is Singleton vs Dependency Injection?

Singleton controls lifetime; DI controls dependency management.

---

## 19. How is Singleton used in ASP.NET Core?

Using `services.AddSingleton<T>()`.

---

## 20. Difference between Singleton, Scoped, and Transient?

Singleton = one app instance, Scoped = one request, Transient = new every time.

---

## 21. Should DB connection be Singleton?

No, use connection pooling instead.

---

## 22. Should logger be Singleton?

Usually yes, because logging is centralized shared functionality.

---

## 23. Is Singleton one object across all servers?

No, Singleton is one object per application process.

---

## 24. Can reflection break Singleton?

Yes, reflection can access private constructors.

---

## 25. Can serialization break Singleton?

Yes, deserialization may create new instances.

---

## 26. How to prevent reflection attack on Singleton?

Throw exception if constructor is called more than once.

---

## 27. How to test Singleton-based code?

Use interfaces and dependency injection.

---

## 28. What is `Lazy<T>` in Singleton?

A thread-safe lazy initialization helper in C#.

---

## 29. Is Singleton good for microservices?

Only for process-local shared services, not distributed shared state.

---

## 30. When should you avoid Singleton?

When global mutable state can cause tight coupling or concurrency issues.

---

## 31. What is the biggest advantage of Singleton?

Controlled access to a shared resource with reduced memory usage.

---

## 32. What is the biggest disadvantage of Singleton?

Hidden dependencies and hard-to-test code.

---

## 33. Can Singleton have constructor parameters?

Yes, but DI containers handle this better.

---

## 34. What happens if constructor is public?

Anyone can create multiple objects, breaking Singleton.

---

## 35. Can multiple Singleton instances exist accidentally?

Yes, if implementation is not thread-safe.

---

## 36. Is Singleton object created in heap or stack?

Heap, because it is a reference type object.

---

## 37. Why do modern applications prefer DI-managed Singleton?

Because it provides loose coupling and easier testing.

---

## 38. What is global access point in Singleton?

A static method/property returning the shared instance.

---

## 39. Can Singleton maintain shared state?

Yes, all consumers access the same object state.

---

## 40. Interview summary line?

Singleton ensures one shared instance with centralized access across the application.

---

Lifetime ASP.NET Core Created
AddSingleton<T>() One per app Once at startup
AddScoped<T>() One per HTTP request Per request
AddTransient<T>() New every time Per injection

---

Singleton pattern = manual lifetime control
DI container = automated lifetime control
AddSingleton() = clean replacement for Singleton pattern

---

Singleton can depend on → Singleton only
Scoped can depend on → Singleton, Scoped
Transient can depend on → Singleton, Scoped, Transient (most flexible)

// ✅ Option 1 — all Singleton (most common for this use case)
services.AddSingleton<ILoggerService, GoodLoggerService>();
services.AddSingleton<GoodPaymentService>();
services.AddSingleton<GoodOrderService>();

// ✅ Option 2 — all Transient (new everything, every time)
services.AddTransient<ILoggerService, GoodLoggerService>();
services.AddTransient<GoodPaymentService>();
services.AddTransient<GoodOrderService>();

// ✅ Option 3 — all Scoped (one set per request)
services.AddScoped<ILoggerService, GoodLoggerService>();
services.AddScoped<GoodPaymentService>();
services.AddScoped<GoodOrderService>();

// ❌ Never do this — short lifetime injected into longer lifetime
services.AddTransient<ILoggerService, GoodLoggerService>(); // shorter
services.AddSingleton<GoodPaymentService>(); // longer — captures transient!

//-------------------------------------------------------------------------------------------------------------

| Pattern                    | Thread-safe        | Lazy init      | Lifetime             | Notes                       |
| -------------------------- | ------------------ | -------------- | -------------------- | --------------------------- |
| New per class (`new`)      | ⚠️ Depends         | ✗ No           | Per object           | Tightly coupled             |
| Eager singleton            | ✓ CLR static init  | ✗ No           | App-wide             | Created immediately         |
| Lazy singleton (`Lazy<T>`) | ✓ `Lazy<T>`        | ✓ Access-lazy  | App-wide             | Created on first access     |
| DI — Singleton             | ✓ Container        | ✓ Resolve-lazy | App-wide             | One shared instance         |
| DI — Scoped                | ✓ Container        | ✓ Resolve-lazy | Per scope/request    | Shared within scope         |
| DI — Transient             | ✓ Container        | ✓ Resolve-lazy | Per resolve          | New each time               |
| DI + `Lazy<T>`             | ✓ Both             | ✓ Access-lazy  | Depends on DI        | Delayed dependency creation |
| DI + Manual Singleton      | ⚠️ Mixed ownership | ✓ Access-lazy  | Effectively app-wide | DI lifetime ignored         |

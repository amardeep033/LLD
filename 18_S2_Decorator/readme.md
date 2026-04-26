Use decorator when you have features that can be mixed and matched on the same core action.
The two triggers:

Combinable features — encryption, compression, auth, retry — any subset can apply, in any order
Same interface in, same interface out — every step takes IFileWriter returns IFileWriter, the chain stays uniform

//-----------------------------------------------------------------------------------------------------------------


IHttpClient client = 
    new LoggingDecorator("RETRY",
        new RetryDecorator(
            new LoggingDecorator("AUTH",
                new AuthDecorator(
                    new LoggingDecorator("HTTP",
                        new HttpClient()
                    )
                )
            )
        )
    );

No, that's not prod code. The manual nesting gets ugly fast. In prod you'd use a DI container (like in ASP.NET) that composes this for you — you just register decorators and the container wires them up.
And yes — logging is a slightly wrong fit here. The reason:
Logging is a cross-cutting concern — it doesn't belong in the pipeline chain, it belongs around everything. That's why in real apps logging lives in:

Middleware (ASP.NET) — one place, logs every request/response
ILogger injection — each class logs itself, not via wrapping
OpenTelemetry / Serilog — observability layer, completely outside your classes

Decorator shines when the behavior changes the request itself — like:

AuthDecorator — mutates the request (adds token)
RetryDecorator — changes execution behavior (retries on failure)
CachingDecorator — short-circuits the call entirely
CompressionDecorator — transforms the payload

These are functional concerns — they change what happens. Logging is an observational concern — it just watches what happens without affecting it.

So your example is perfect for learning the pattern — it makes the wrapping visible. But in prod, logging would be pulled out and the composition would be handled by DI. The AuthDecorator and RetryDecorator are the real decorator pattern story here.

IPayment payment = new FraudCheckDecorator(
    new CurrencyConversionDecorator(
        new PaymentGateway()
    )
);

IFileWriter writer = new EncryptionDecorator(
    new CompressionDecorator(
        new FileWriter()
    )
);

//------------------------------------------------------------------------------------------------------------------

What problem does decorator solve? — Add behavior to an object at runtime without changing its class or creating subclasses for every combination.
How is decorator different from inheritance? — Inheritance is compile-time and causes class explosion for combinations; decorator is runtime and composes behavior flexibly.
What's the one rule every decorator must follow? — It must implement the same interface as the thing it wraps — that's what makes them stackable and interchangeable.
Does order of decorators matter? — Yes. Encrypt(Compress(file)) vs Compress(Encrypt(file)) produces different output — order defines the pipeline.
How is decorator different from chain of responsibility? — Decorator wraps and always delegates inward; chain of responsibility passes along a chain and any handler can stop it.
What design principles does decorator follow? — OCP (new class for new behavior), SRP (each decorator does one thing), composition over inheritance.
What's the difference between decorator and proxy? — Proxy controls access to the object (auth, lazy load, caching); decorator adds behavior to it. Intent is different even if structure looks similar.
When would you NOT use decorator? — When behavior isn't composable, when you need to change core logic, or when a DI container + middleware pipeline already handles it better.
Where is decorator used in the real world / frameworks? — ASP.NET middleware pipeline, Java I/O streams (BufferedReader(FileReader())), Python @decorators, Axios interceptors.
What's the difference between decorator and builder pattern? — Builder constructs an object step by step with a different final type; decorator wraps an existing object and always returns the same interface.
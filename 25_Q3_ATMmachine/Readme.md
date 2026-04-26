Q3 — Design an ATM Machine
Why this question?
PatternRole in ATMStateATM machine itself — Idle → Card Inserted → Authenticated → Dispensing → Out of CashChain of ResponsibilityCash dispensing — ₹2000 handler → ₹500 → ₹200 → ₹100 handler chainProxyBankAccountProxy — sits between ATM and real bank account; enforces PIN check, daily limit, session auth before forwardingFacadeATMFacade — single entry point hiding CardReader, CashDispenser, BankNetwork, ReceiptPrinter complexity

Requirements

ATM should accept a card and ask for PIN
After 3 wrong PINs, card should be blocked
User can check balance, withdraw cash, or cancel
Cash withdrawal should dispense using available note denominations (e.g. ₹2000, ₹500, ₹200, ₹100)
ATM should track its own cash inventory — if insufficient, reject the transaction
ATM should transition to an OutOfCash state when empty
All bank calls (balance fetch, debit) go through a proxy that validates session & daily limits
The client (ATM UI / terminal) calls only a single facade — it should not know about internal subsystems


Class structure to design
ATMMachine                        ← holds current IATMState
│
├── IATMState (interface)
│   ├── IdleState
│   ├── CardInsertedState
│   ├── AuthenticatedState
│   ├── TransactionState
│   └── OutOfCashState
│
├── ATMFacade                     ← single entry point for terminal
│   ├── CardReader
│   ├── CashDispenser
│   ├── ReceiptPrinter
│   └── IBankService
│
├── IBankService (interface)
│   ├── RealBankService           ← actual network call
│   └── BankServiceProxy          ← PIN check, daily limit, session guard
│
└── CashHandler (abstract)        ← Chain of Responsibility
    ├── TwoThousandHandler
    ├── FiveHundredHandler
    ├── TwoHundredHandler
    └── HundredHandler

Constraints & edge cases to handle

Withdrawal amount must be a multiple of ₹100
ATM inventory is finite — track note counts per denomination
Partial dispense is not allowed (reject if exact amount can't be formed)
Session expires after 60 seconds of inactivity → transition back to IdleState
Proxy must log every transaction attempt (success or failure)
CancelTransaction should be callable from any state and always return to IdleState


Sequence to implement
1. Model ATMState interface + all 5 states         ← State pattern
2. Build CashHandler chain                         ← Chain of Responsibility
3. Build RealBankService + BankServiceProxy        ← Proxy pattern
4. Wire CardReader, CashDispenser, ReceiptPrinter  
   behind ATMFacade                                ← Facade pattern
5. ATMMachine holds current state + facade ref
6. Write a Program.cs that simulates:
   insert card → enter PIN → withdraw ₹2300 → receipt → eject card

Stretch goals (if you finish early)

Add AdminState — lets technician refill cash inventory
Make BankServiceProxy a caching proxy — cache balance for 30 seconds to avoid repeated network calls
Add ILogger injected into Proxy and each State for audit trail


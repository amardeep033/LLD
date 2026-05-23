# ATM Machine Codebase Structure

This project simulates an ATM using OOP and design patterns. Here’s a quick reference to understand and navigate the code:

## 1. Interfaces
**1.1 IBankService** — Implemented by `BankServiceProxy` and `RealBankService` (which manages `UserAccount`).
**1.2 IATMState** — Implemented by state classes: `StatusIdle`, `StatusCardInserted`, `StatusAuthenticated`, `StatusDispensingCash`, `StatusOutOfCash`.
**1.3 IDenominationHandler** — Implemented by `DenominationHandler` (base for `Denomination2000`, `Denomination500`, `Denomination200`, `Denomination100`). Defines `CanDispense` and `Deduct`.

## 2. Main Classes
**2.1 ATMInventory** — Manages cash inventory (add, remove, print, dispense).
**2.2 ATMService** — Core ATM logic: handles user actions, state, and session management.
**2.3 ATMFacade** — Entry point for all ATM operations (simulates CardReader, CashDispenser, Display, ReceiptPrinter, Cancel).
**2.4 Factory** — Builds the chain of `IDenominationHandler` for cash dispensing.

## 3. UserAccount
**Properties:** `AccountId`, `Pin`, `Balance`, `IsBlocked`, `DailyLimit`, `WithdrawnToday`.

## 4. ATM (ATMService)
**States:** `StatusIdle`, `StatusCardInserted`, `StatusAuthenticated`, `StatusDispensingCash`, `StatusOutOfCash`.
**Methods:** `Status`, `ActionInsertCard`, `ActionEnterPin`, `ActionCheckBalance`, `ActionDispenseCash`, `ActionCancel`.

## 5. ATMInventory
**Properties:** `cashInventory`
**Methods:** `GetTotalCash`, `PrintInventory`, `DispenseCash`

## 6. DenominationHandler
**Properties:** `SetNext`
**Methods:** `CanDispense`, `Deduct`, `HandleCanDispenseNext`, `HandleDeductNext`

## 7. IBankService / RealBankService
**Properties:** `UserAccount`
**Methods:** `ValidatePin`, `GetBalance`, `Debit`, `BlockCard`, `GetDailyLimit`, `GetAmountWithdrawnToday`, `LogTransaction`

## 8. BankServiceProxy (Proxy)
**Properties:** `RealBankService`, `_isSessionActive`, `_activeUserId`, `_dailyLimitCache`
**Methods:** `StartSession`, `EndSession`, `GuardSession`

## 9. ATMService (Core ATM)
**Properties:** `Id`, `State`, `timeout`, `lastActionTime`
**Methods:** `ActionInsertCard`, `ActionEnterPin`, `ActionCheckBalance`, `ActionDispenseCash`, `ActionCancel`, `SetState`, `CheckSessionTimeout`, `RecordAction`, `PrintStatus`

## 10. ATMFacade (Main API)
**Properties:** `ATMService`, `IBankService`, `ATMInventory`, `Denomination`
**Methods:** `InsertCard`, `EnterPin`, `CheckBalance`, `WithdrawCash`, `Cancel`, `ShowInventory`, `PrintReceipt`

-----------------------------------------------------------------------------

Flow for cash withdrawal:
1. User inserts card → `InsertCard(userId)` (ATMFacade) → `ActionInsertCard` (ATMService) → State: `StatusCardInserted`
2. User enters PIN → `EnterPin(pin)` (ATMFacade) → `ActionEnterPin` (ATMService) → PIN validated via `BankServiceProxy`
   - If valid: State → `StatusAuthenticated`
   - If invalid: Error or card blocked after 3 attempts
3. User requests withdrawal → `WithdrawCash(amount)` (ATMFacade) → `ActionDispenseCash` (ATMService)
4. ATMService delegates to current state (`StatusAuthenticated`):
   - Calls `ATMInventory.DispenseCash(userId, amount, bank)`
   - Uses DenominationHandler chain to check and deduct notes
   - BankServiceProxy checks balance, daily limit, logs transaction
5. If successful:
   - Cash dispensed, inventory updated
   - State → `StatusIdle` (session ends, card ejected)
   - Receipt printed
6. If unsuccessful:
   - Error shown (insufficient funds, invalid amount, etc.)
   - State may remain authenticated or return to idle
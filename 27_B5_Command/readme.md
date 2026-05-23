# Design Pattern Interview — Quick Q&A

---

## Command Pattern

**Q: What is the Command Pattern?**
A: It encapsulates a request as an object, letting you parameterize, queue, log, or undo actions.

**Q: What is the single method in a Command interface?**
A: `Execute()` — the invoker only ever calls this, knowing nothing about what it does.

**Q: What are the four participants in Command Pattern?**
A: Command (interface), ConcreteCommand (implementation), Invoker (button), Receiver (Light/Fan).

**Q: How does Command Pattern differ from DI + Interface?**
A: DI injects _who does the work_ (a device); Command encapsulates _what work gets done_ (an action).

**Q: How do you implement Undo using Command Pattern?**
A: Add an `Undo()` method to the interface; each command reverses its own `Execute()` logic.

**Q: Can one button trigger multiple actions in Command Pattern?**
A: Yes — via a MacroCommand that holds a list of commands and calls `Execute()` on each.

**Q: Is Command Pattern the same as Strategy Pattern?**
A: No — Strategy swaps _how_ an algorithm runs; Command encapsulates _a request_ as an object with optional undo/queue.

**Q: What real-world systems use Command Pattern?**
A: Text editor undo/redo, job queues, transaction logs, UI button handlers, and macro recorders.

**Q: When should you NOT use Command Pattern?**
A: When actions are simple and will never need undo, queuing, or logging — it adds unnecessary classes.

---

## Dependency Injection (DI)

**Q: What is Dependency Injection?**
A: Passing dependencies into a class from outside instead of letting the class create them itself.

**Q: What problem does DI solve?**
A: Tight coupling — without DI, a class is locked to one concrete implementation forever.

**Q: What are the three types of DI?**
A: Constructor injection, property injection, and method injection.

**Q: Which DI type is preferred and why?**
A: Constructor injection — dependencies are explicit, mandatory, and available from object creation.

**Q: What principle does DI implement?**
A: Dependency Inversion Principle (DIP) — depend on abstractions, not concretions.

**Q: What is the difference between DI and a DI Container?**
A: DI is a pattern; a DI Container (e.g. .NET's IServiceCollection) automates resolving and injecting dependencies.

---

## Interface-Based Design

**Q: Why program to an interface, not a concrete class?**
A: It decouples the caller from the implementation, making code swappable and testable.

**Q: What SOLID principle does interface-based design enforce?**
A: Open/Closed Principle — open for extension (new implementations), closed for modification.

**Q: What is the difference between an interface and an abstract class?**
A: An interface is a pure contract with no state; an abstract class can have shared state and partial implementation.

---

## General Design Patterns

**Q: What are the three categories of GoF design patterns?**
A: Creational (object creation), Structural (composition), Behavioural (communication) — Command is Behavioural.

**Q: What is the difference between Command and Observer pattern?**
A: Command encapsulates a single request; Observer broadcasts an event to many subscribers.

**Q: What is the difference between Command and Chain of Responsibility?**
A: Command has one designated receiver; Chain of Responsibility passes the request along a handler chain until one handles it.

**Q: What does "encapsulate what varies" mean?**
A: Identify the part of your code that changes, extract it behind an abstraction — that is the core idea behind most patterns.

**Q: What is the difference between coupling and cohesion?**
A: Coupling is how much classes depend on each other (lower is better); cohesion is how focused a class is on one job (higher is better).

---

# Command Pattern vs State Pattern — When to Use What

---

## One-Line Summary

> **Command** — _"What should happen?"_ → encapsulates an action as an object.  
> **State** — _"What is allowed to happen right now?"_ → object changes behaviour based on its current mode.

---

## Tell-Tale Signs in Requirements

| If the requirement says...                       | Use     |
| ------------------------------------------------ | ------- |
| "User can undo / redo actions"                   | Command |
| "Actions need to be queued or scheduled"         | Command |
| "Every action should be logged or audited"       | Command |
| "One button should trigger multiple actions"     | Command |
| "Behaviour changes based on current mode"        | State   |
| "Invalid transitions must be blocked"            | State   |
| "Same method does different things per state"    | State   |
| "You have a growing if/switch on a status field" | State   |

---

## Fan Example — Same Domain, Different Concern

**Command Pattern** (your code):

```
User presses button → Execute FanOn
User presses button → Execute FanOff
User presses undo   → Undo FanOff
```

Fan does not care about its current state. You tell it what to do, it does it.  
`FanOff` can be called even if the fan is already off — no one checks.

**State Pattern** — same fan, different concern:

```
Fan is OFF   → PressOn    → ✅ allowed   → Fan goes ON
Fan is ON    → PressPause → ✅ allowed   → Fan goes PAUSED
Fan is OFF   → PressPause → ❌ blocked   → "Can't pause, fan is off"
```

Now the fan knows its own state and decides what transitions are valid.

---

## Real-World Split

| Scenario                             | Pattern | Why                                  |
| ------------------------------------ | ------- | ------------------------------------ |
| Ctrl+Z in a text editor              | Command | History of actions to reverse        |
| Traffic light (Red → Green → Yellow) | State   | What's allowed changes per state     |
| Order lifecycle (Placed → Shipped)   | State   | Can't ship a cancelled order         |
| Job queue in a background service    | Command | Commands travel and execute later    |
| Vending machine (idle / has money)   | State   | Behaviour locked by current mode     |
| Remote control buttons               | Command | Each press is an encapsulated action |

---

## They Can Work Together

```
Fan uses State Pattern internally:
    OFF → ON → PAUSED → OFF

Remote uses Command Pattern externally:
    FanOnCommand.Execute()
        → asks fan to turn on
        → Fan's State decides if it's valid
        → if valid, transitions + records history
```

Command answers _"what to do"_.  
State answers _"is it valid right now"_.

---

## Quick Pattern Reference

### Command Pattern

- **Participants:** `ICommand` (interface), ConcreteCommand, Invoker, Receiver
- **Key method:** `Execute()` — invoker calls only this
- **Undo:** add `Undo()` to interface; use `Stack<ICommand>` in invoker for multi-step history
- **Macro:** `MacroCommand` holds `List<ICommand>` and calls `Execute()` on each

### State Pattern

- **Participants:** Context (object with state), `IState` (interface), ConcreteStates
- **Key idea:** each state is its own class with its own behaviour — no giant if/switch
- **Transitions:** state transitions itself internally; context usually doesn't know what comes next

---

## vs DI + Interface

|                            | DI + Interface | Command | State |
| -------------------------- | -------------- | ------- | ----- |
| Swaps _who_ does the work  | ✅             | ✅      | —     |
| Swaps _what_ action runs   | ❌             | ✅      | —     |
| Controls _what is allowed_ | ❌             | ❌      | ✅    |
| Undo / Queue / Log         | ❌             | ✅      | ❌    |

---

## One-Line Interview Answer

> _"Command Pattern captures actions as objects for control over execution — undo, queue, log.  
> State Pattern changes an object's own behaviour based on what state it is currently in."_

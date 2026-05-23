# 🏠 Home Automation System — Design Patterns Interview Question

A practical interview question covering **Singleton**, **Composite**, and **Command** patterns in a single cohesive problem.

---

# 📋 Problem Statement

Design a **Smart Home Automation System** with the following requirements:

- A single `SmartHomeHub` that controls access to all devices in the home.
- Devices are organized in a hierarchy:
  - A `Home` contains `Rooms`
  - A `Room` contains `Devices`

- All levels must support a uniform interface:
  - `turnOn()`
  - `turnOff()`

- An `AutomationController` should:
  - queue commands
  - execute commands
  - undo commands

---

# ✅ Required Features

Your solution must support:

```
execute()     -> run a single command
undo()        -> revert the last executed command
executeAll()  -> run all queued commands
```

---

# 🧩 Pattern Mapping

| Pattern   | Category    | Where It's Used                                                       |
| --------- | ----------- | --------------------------------------------------------------------- |
| Singleton | Creational  | `SmartHomeHub` — one global instance manages the entire system        |
| Composite | Structural  | `Home → Room → Device` hierarchy with uniform `On()/Off()` operations |
| Command   | Behavioural | `Remote/AutomationController` queues, executes, and undoes operations |

---

# 🔗 Pattern Interaction

The patterns chain naturally:

```
Command
   ↓
calls On()/Off()
   ↓
on Composite nodes
   ↓
accessed through SmartHomeHub Singleton
```

---

# 🎯 Bonus Follow-up Questions

These are common interview follow-ups after the base implementation.

| Question                                             | Pattern Tested |
| ---------------------------------------------------- | -------------- |
| How do you make `SmartHomeHub` thread-safe?          | Singleton      |
| What if a `Room` can contain sub-rooms?              | Composite      |
| How would you implement a "Night Mode" macro?        | Command        |
| How do you maintain command history?                 | Command        |
| What if two threads execute commands simultaneously? | All Patterns   |

---

# 🌙 Example: Night Mode Macro

```
Turn off all lights
Set AC to 22°
Lock doors
```

This can be implemented using a `MacroCommand`
that internally executes multiple commands.

---

# ✅ Evaluation Checklist

Your implementation should satisfy:

- `SmartHomeHub` cannot be instantiated more than once
- `turnOn()` on a `Room` recursively calls `turnOn()` on all children
- `Device` and `Room` are interchangeable through a common abstraction
- `undo()` correctly reverses the last executed command
- `AutomationController` is decoupled from concrete devices
- Bonus: `MacroCommand` support

---

# 🏗️ Final Architecture

```
SmartHomeHub (Singleton)
│
├── Home (Composite Root)
│    ├── Room
│    │    ├── Device
│    │    └── Device
│    │
│    └── Room
│         ├── Device
│         └── Device
│
└── Remote / AutomationController (Command Invoker)
```

---

# 🤔 Design Decisions & Doubts

---

## Doubt 1 — Should `Add()` / `Remove()` exist in `IStructure`?

### Answer:

No.

This is a classic Composite Pattern trade-off:

---

### 1. Transparent Composite

Put `Add()` / `Remove()` inside `IStructure`.

### Pros

- Caller can uniformly manipulate the tree

### Cons

- Leaf nodes (`Device`) must implement methods that make no sense
- Often results in:

  ```csharp
  throw new NotSupportedException();
  ```

---

### 2. Safe Composite (Current Design)

Keep `Add()` / `Remove()` only in composite nodes:

- `Home`
- `Room`

### Pros

- Cleaner leaf nodes
- Better semantic correctness

### Cons

- Tree construction requires knowledge of concrete composite types

---

### Decision

For this problem, **Safe Composite** is the better choice because:

- Tree construction happens only once during setup
- `IStructure` should only expose behavior common to every node:
  - `Show()`
  - `On()`
  - `Off()`

---

# 🤔 Doubt 2 — Should `Queue()` exist inside `ICommand`?

### Answer:

No.

`Queue()` does **not** belong to the command itself.

---

## Why?

Queueing is the responsibility of the:

```
Invoker / Controller
```

not the command.

Commands should only know:

```csharp
Execute()
Undo()
```

---

## Correct Responsibility Separation

| Responsibility      | Class              |
| ------------------- | ------------------ |
| Execute operation   | `ICommand`         |
| Maintain queue      | `Remote`           |
| Maintain history    | `Remote`           |
| Perform actual work | `Home/Room/Device` |

---

# 🤔 Doubt 3 — DI Container Misunderstanding

This is incorrect:

```csharp
provider.GetRequiredService<Remote>("Main Remote");
```

---

## Why?

A DI container is meant to:

```
Build object graphs using registrations
```

NOT:

```
Call constructors with arbitrary runtime parameters
```

---

## Important Distinction

### DI Containers Resolve:

- Services
- Dependencies
- Shared application objects

### DI Containers Do NOT Automatically Resolve:

- Arbitrary runtime values
- Dynamic entity names
- User-generated constructor data

---

# 🧠 Key Learning from This Exercise

The hardest part of LLD is usually **not writing classes**.

It is:

```
Object orchestration
```

Meaning:

- creation order
- dependency flow
- runtime interaction
- command execution sequence
- ownership boundaries

---

# 🚀 Final Takeaway

This problem demonstrates how multiple design patterns collaborate in a real system:

- **Composite** models hierarchy
- **Command** models actions
- **Singleton** provides centralized coordination

The real challenge is not memorizing patterns —
it's understanding:

- responsibility boundaries
- runtime flow
- object collaboration
- extensibility tradeoffs

//----------------------------------------------------

ToDo:
1. rooms inside room
2. macro command
3. state level command like set temperature to 22 degrees

//-----------------------------------------------------
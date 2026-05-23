# LLD Design Patterns — Interview Reference

> Ranked by frequency across ~35 canonical Low-Level Design interview questions (rank 1 = most frequent).
> A single question may appear under multiple patterns.

---

| Rank | Pattern | Type | Interview Questions |
|------|---------|------|---------------------|
| 1 | Observer | Behavioural | Ride Sharing (Uber/Lyft), Elevator System, Food Delivery (Zomato/Swiggy), Movie Ticket Booking (BookMyShow), Notification System, Pub-Sub / Message Queue, Social Media Feed (Twitter/LinkedIn/Instagram), Stock Exchange / Trading Platform, Task Scheduler / Job Queue, Cricket Scorecard, Traffic Light System, Chess Game, Snake and Ladder, TicTacToe, E-commerce (Amazon), Splitwise / Bill Splitting, Online Code Editor (LeetCode), Library Management System, Hospital Management System |
| 2 | Strategy | Behavioural | Ride Sharing (driver matching / pricing), Food Delivery (routing), Payment Gateway, Rate Limiter, E-commerce (discount / sorting), Social Media Feed (ranking), Stock Exchange (order matching), LRU Cache (eviction policy), Splitwise (split algorithm), Chess (move validation), Snake and Ladder, Elevator (scheduling), Logger (log level), Car Rental, Online Code Editor (execution engine), Inventory Management, Hotel Booking, Hospital Management |
| 3 | Factory / Factory Method | Creational | Parking Lot (vehicle/ticket factory), Vending Machine (product factory), Hotel Management, Car Rental, Ride Sharing (vehicle factory), Food Delivery, Movie Ticket Booking, Notification System (channel factory), E-commerce (payment factory), Social Media (post factory), Cricket Scorecard, Library Management, Chess (piece factory), Snake and Ladder, Inventory Management, Hospital Management |
| 4 | State | Behavioural | Parking Lot (slot states: free/occupied/reserved), Elevator (idle/moving/door-open), Vending Machine (idle/has-money/dispensing), ATM Machine (idle/card-inserted/pin-entered), Traffic Light System, Hotel Management (room states), Car Rental (vehicle states), Hospital Management (bed/appointment states), Order Management System |
| 5 | Decorator | Structural | Notification System (SMS + Email + Push stacking), Rate Limiter (layered throttling), E-commerce (pricing: base + tax + discount), LRU Cache (add logging/metrics), Logger (add timestamp/format layers), API Gateway (auth + logging + rate-limit wrapping) |
| 6 | Singleton | Creational | Logger (single global logger instance), Parking Lot (single lot manager), Movie Ticket Booking (seat lock manager), Library Management (catalogue manager), Configuration / Feature Flag Manager |
| 7 | Command | Behavioural | ATM Machine (deposit/withdraw as commands), Task Scheduler / Job Queue (encapsulate tasks), Online Code Editor — undo/redo history, Smart Home System (device commands) |
| 8 | Chain of Responsibility | Behavioural | Logger (DEBUG → INFO → WARN → ERROR chain), Payment Gateway (fraud check → bank → fallback), ATM Machine (cash dispense denomination chain) |
| 9 | Composite | Structural | File System Design (file and folder as uniform nodes), E-commerce Category Tree (leaf product vs category node), Menu Builder (item vs combo) |
| 10 | Builder | Creational | Query Builder / ORM (complex SQL object construction), Report Generator (multi-section report assembly), HTTP Request Builder |

---

## Pattern type summary

| Type | Patterns in this list |
|------|-----------------------|
| Behavioural | Observer, Strategy, State, Command, Chain of Responsibility |
| Creational | Factory / Factory Method, Singleton, Builder |
| Structural | Decorator, Composite |

---

## Frequently combined pattern pairs

| Pattern A | Pattern B | Common question |
|-----------|-----------|-----------------|
| Observer | Strategy | Ride Sharing, Stock Exchange, Social Media Feed |
| Factory | State | Parking Lot, Vending Machine, Elevator |
| Observer | Factory | Movie Ticket Booking, Notification System |
| Decorator | Strategy | Rate Limiter, Logger |
| Command | Observer | Task Scheduler, Online Code Editor |

---

*Source: aggregated from standard FAANG / product-company LLD interview question sets.*

Pattern	Frequency
Strategy	41
Observer	29
State	11
Composite	11
Iterator	6
Factory	6
Singleton	5
Mediator	3
Template Method	3
Decorator	3
Facade	3
Chain of Responsibility	2
Adapter	2
Repository/DAO	2
Proxy	2
Null Object	1
Visitor	1
Flyweight	1
Abstract Factory	1
Command	1

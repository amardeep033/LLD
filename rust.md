1. struct: A struct is a custom data type that lets you group related data under one name.
struct Invoice {
    amount: f64,
}


2. trait: A trait in Rust is like an interface in other languages — it defines a set of required methods a type must implement. 
I use traits to define shared behavior across multiple types. This allows polymorphism and clean abstractions.
trait Discount {
    fn apply(&self, price: f64) -> f64;
}

3. impl: Short for implementation block — impl is where we define methods/functions for a struct or implement traits.
impl Invoice {
    fn calculate_total(&self) -> f64 {
        self.amount * 1.18
    }
}

4. fn: This is how you define a function in Rust. Inside an impl block, it's a method. Outside, it’s a regular function.
fn checkout(price: f64, discount: &dyn Discount) -> f64 {
    discount.apply(price)
}


-----------------------------------------------------------------------------------------------------------------------------

| Component | Role                 | Required?  | Notes                                      |
| --------- | -------------------- | ---------- | ------------------------------------------ |
| `struct`  | Data holder          | ✅ Yes      | Represents the entity/data model           |
| `trait`   | Behavior abstraction | ❌ Optional | Defines a contract (like an interface)     |
| `impl`    | Implementation block | ✅ Yes      | Implements methods for `struct` or `trait` |
| `fn`      | Function/method      | ✅ Yes      | Actual logic (inside `impl` or standalone) |

-----------------------------------------------------------------------------------------------------------------------------

// 1. Define struct
struct Invoice {
    amount: f64,
}

// 2. Define trait (optional)
trait Printable {
    fn print(&self);
}

// 3. impl for struct's own methods
impl Invoice {
    fn calculate_total(&self) -> f64 {
        self.amount * 1.18
    }
}

// 4. impl trait for struct
impl Printable for Invoice {
    fn print(&self) {
        println!("Total: {}", self.calculate_total());
    }
}


-----------------------------------------------------------------------------------------------------------------------------
fn overriding in rust

trait Animal {
    fn speak(&self) {
        println!("Some generic animal sound");
    }
}

struct Dog;

impl Animal for Dog {
    // No speak() method here, so Dog uses the default one
}

struct Cat;

impl Animal for Cat {
    fn speak(&self) {
        println!("Meow!");
    }
}

fn make_sound(animal: &dyn Animal) {
    animal.speak();
}

fn main() {
    let dog = Dog;
    let cat = Cat;

    make_sound(&dog); // prints: Some generic animal sound
    make_sound(&cat); // prints: Meow!
}
------------------------------------------------------------------------------------------------

-> Abstract Class  |single inheritance  |both abs and conc fn  |extends|Animal(Cat,Dog)  |is-a
-> Interface  |multiple inheritance|  only abs|  implements|  (Flyer,Eater)Duck|  is-a
-> Composition/aggregation class  |another class as a field  |Car class contains engine class  |has-a

-> class->abstraction class->subclass(concrete class)  |  class Payment->interface Payment strategy->class cashPayment, class creditCardPayment
-> class->interface->implementer(concrete class)  |  class parkingLot->abstract class ParkingSpot -> class CarSpot, class BikeSpot

---------------------------------------------------------------------------------------------------------
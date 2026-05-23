using _3_Inheritance;
using _3_Inheritence;

//BAD INHERITANCE — client must call separate methods manually
BadSavingsAccount badSavings = new BadSavingsAccount();
badSavings.OpenSavingsAccount();
badSavings.DisplaySavingsBalance();

BadCurrentAccount badCurrent = new BadCurrentAccount();
badCurrent.OpenCurrentAccount();
badCurrent.DisplayCurrentBalance();

//GOOD INHERITANCE — client can call a single method to perform all related operations
//client calls shared methods, behavior differs by child class
GoodAccounts savings = new SavingsAccount();
savings.OpenAccount();
savings.DisplayBalance();

GoodAccounts current = new CurrentAccount();
current.OpenAccount();
current.DisplayBalance();

//inheritance allows us to treat different account types uniformly, while still maintaining their unique behaviors.
// is-a relationship: SavingsAccount is a GoodAccounts, CurrentAccount is a GoodAccounts
// promotes code reuse and flexibility, as we can add new account types by simply creating new classes that inherit from GoodAccounts without changing existing code.
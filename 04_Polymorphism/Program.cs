using _4_BadPolymorphism;
using _4_GoodPolymorphism;

//referenceType objectName = new ObjectType
//reference type decides what i can call and checked at compile time
//object type decides what actually runs and checked at run time

//-------------------------------------------------------

BadAccounts badacc1 = new BadSavingsAccount();
badacc1.OpenAccount(); //parent -- not overriding -----------
badacc1.DisplayBalance(); //parent -- not overriding -------
badacc1.CommonWelcomeMessage(); //parent
//badacc1.BadAccountsOwnFunction(); //not possible

BadSavingsAccount badacc2 = new BadSavingsAccount();
badacc2.OpenAccount(); //child
badacc2.DisplayBalance(); //child
badacc2.CommonWelcomeMessage(); //inheritance
badacc2.BadAccountsOwnFunction(); //possible - child

// BadSavingsAccount badacc3 = new BadAccounts(); // not possible because 

BadAccounts badacc4 = new BadAccounts();
badacc4.OpenAccount(); //parent
badacc4.DisplayBalance(); //parent
badacc4.CommonWelcomeMessage(); //parent
//badacc4.BadAccountsOwnFunction(); //not possible

//-------------------------------------------------------

GoodAccounts goodacc1 = new GoodSavingsAccount();
goodacc1.OpenAccount(); //overriding ---------------------
goodacc1.DisplayBalance(); //overriding ---------------------
goodacc1.CommonWelcomeMessage(); //parent
// goodacc1.GoodAccountsOwnFunction(); //not possible

GoodSavingsAccount goodacc2 = new GoodSavingsAccount();
goodacc2.OpenAccount(); //child
goodacc2.DisplayBalance(); //child
goodacc2.CommonWelcomeMessage(); //inheritance
goodacc2.GoodAccountsOwnFunction(); //child

// GoodSavingsAccount goodacc3 = new GoodAccounts(); // not possible because 

// GoodAccounts goodacc4 = new GoodAccounts(); //not possible - 


GoodAccounts goodaccx = new GoodCurrentAccount();
goodaccx.OpenAccount(); //child
goodaccx.DisplayBalance(); //parent - through virtual
goodaccx.CommonWelcomeMessage(); //parent
// goodaccx.GoodAccountsOwnFunction(); //not possible
//-------------------------------------------------------

//hiding -- child as ref -- when want to access child fn 
//overriding -- parent as ref -- but want child impl of common fn -- helps in treating everything as one datatype like in list -- basically lets say common processing fn for all child

//static polymorphism - fn overloading - same fn name diff args -- compile time just like operator overloading
//runtime polymorphism - fn overriding - using polymorphism


//abstract - when i want to force the child to override
//virtual - when def impl is there in parent, optional for child to override
//override - to override abstract or virtual fn


//why to override when child can contain directly -- and i can ref type of child 
//but then i will have different datatype -- can't be contained in same list or can't call same fn 

// List<Object> accounts = new List<object>(); // can contain any object -- so cant access their fields -- write if else check - get obj type then only we can get fields for that obj -- whenever something gets added - modify it
// accounts.Add(goodacc1);
// accounts.Add(goodacc2);

List<GoodAccounts> accounts = new List<GoodAccounts>(); 
accounts.Add(goodacc1);
accounts.Add(goodacc2);
foreach (GoodAccounts acc in accounts)
{
    acc.OpenAccount(); //Opening Good Savings Account.
}

List<GoodAccounts> accounts2 = new List<GoodAccounts>(); 
accounts2.Add(goodacc1);
accounts2.Add(goodaccx);
foreach (GoodAccounts acc in accounts2)
{
    acc.OpenAccount(); //Opening Good {acc_type} Account.
}
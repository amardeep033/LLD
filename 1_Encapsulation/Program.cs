using Encapsulation;

//Before Encapsulation
BadAccounts account = new BadAccounts();
account.balance = -10;

Console.WriteLine($"Total Balance: {account.balance}");

//After Encapsulation
GoodAccounts goodAccount1 = new GoodAccounts(); 
goodAccount1.Deposit(100);
Console.WriteLine($"Total Balance: {goodAccount1.GetBalance()}");

try
{
    goodAccount1.Withdraw(150);
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}

// Encapsulation - in one unit - class - fn and variable
// getter setter - properties - no one can modify
// logic at one place - deposit and withdraw - validation at one place - no one can modify balance directly
// data hiding - balance is hidden from outside world - only way to modify is through deposit and withdraw methods - this is encapsulation
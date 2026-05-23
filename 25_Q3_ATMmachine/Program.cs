using _25_Q3_ATMmachine;

Console.OutputEncoding = System.Text.Encoding.UTF8;

var atm = new ATMFacade(atmId: 1);

Console.WriteLine("════════════════════════════════════════");
Console.WriteLine(" SCENARIO 1: Normal withdrawal");
Console.WriteLine("════════════════════════════════════════");
atm.InsertCard(1001);
atm.EnterPin(1234);         // correct PIN
atm.CheckBalance();
atm.WithdrawCash(3700);     // 1×₹2000 + 1×₹1000 isn't possible → 1×₹2000 + 3×₹500 + 1×₹200

Console.WriteLine();
Console.WriteLine("════════════════════════════════════════");
Console.WriteLine(" SCENARIO 2: Wrong PIN → card block");
Console.WriteLine("════════════════════════════════════════");
var atm2 = new ATMFacade(atmId: 2);
atm2.InsertCard(1001);
atm2.EnterPin(9999);    // wrong
atm2.EnterPin(9999);    // wrong
atm2.EnterPin(9999);    // wrong → card blocked

Console.WriteLine();
Console.WriteLine("════════════════════════════════════════");
Console.WriteLine(" SCENARIO 3: Insufficient bank balance");
Console.WriteLine("════════════════════════════════════════");
var atm3 = new ATMFacade(atmId: 3);
atm3.InsertCard(1002);  // user 1002 has only ₹2000
atm3.EnterPin(5678);
atm3.WithdrawCash(5000);    // more than account balance → declined by bank

Console.WriteLine();
Console.WriteLine("════════════════════════════════════════");
Console.WriteLine(" SCENARIO 4: Invalid amount");
Console.WriteLine("════════════════════════════════════════");
var atm4 = new ATMFacade(atmId: 4);
atm4.InsertCard(1001);
atm4.EnterPin(1234);
atm4.WithdrawCash(350);     // not a multiple of 100

Console.WriteLine();
Console.WriteLine("════════════════════════════════════════");
Console.WriteLine(" SCENARIO 5: Cancel mid-session");
Console.WriteLine("════════════════════════════════════════");
var atm5 = new ATMFacade(atmId: 5);
atm5.InsertCard(1001);
atm5.EnterPin(1234);
atm5.Cancel();   // user changes mind
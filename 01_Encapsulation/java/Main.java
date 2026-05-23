//to run: javac -d out *.java ---> java -cp out Main 

// import Account; -- if package then only import

//encapsulation - no direct access -- no repeat of logic again and again(at one place)

public class Main {
    public static void main(String[] args){
        
        Account acc = new Account(10);
        // acc.balance=10; -- bad way as full logic everytime changing balance

        acc.deposit(10);
        int val = acc.getBalance();
        // System.out.println("Fetched val %d", val);
        System.out.println("Fetched val "+val);

        acc.withdraw(5);
        int val2 = acc.getBalance();
        System.out.println("Fetched val "+val2);

        try {
            Account acc2  = new Account(5); //acc wont be accessible outside -- have all logic inside one try catch block itself -- instead of multiple try catch
            acc2.withdraw(10);
            int val3 = acc2.getBalance();
            System.out.println("Fetched val "+val3);
        }
        catch(IllegalArgumentException | IllegalStateException ex) {
            System.out.println("Error: "+ex.getMessage());
        }
    }
}
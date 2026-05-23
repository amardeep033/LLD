// package account; -- if separate account folder then only

public class Account {
    private int balance;

    public Account(int bal){
        if(bal<0){
            // System.out.println("Negative balance");
            throw new IllegalArgumentException("Amount must be positive");
        }
        this.balance = bal;
    }

    // public int get_balance(){ //use camelcase for methods name
    public int getBalance(){
        return balance;
    }

    public void deposit(int bal){
        if(bal<=0){
            throw new IllegalArgumentException("Amount must be positive");
        }
        this.balance+=bal;
    }

    public void withdraw(int bal){
        if(bal<=0){
            throw new IllegalArgumentException("Amount must be positive");
        } else if (bal > balance){
            // System.out.println("Not sufficient balance");
            throw new IllegalStateException("Insufficient balance");
        }
        this.balance-=bal;
    }
}
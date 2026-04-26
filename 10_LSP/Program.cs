// Objects of a subclass should be replaceable with objects of the base class without breaking program correctness.
// Its like penguin is-a bird, deposit_acc is bank acc -- but bhvr different -- not worthy of subclass
// no one should silently violate the contract - expected bhvr


using _10_LSP;

BadAccount acc1 = new BadSavingsAccount();
BadAccountProcessor.Process(acc1); //since static function -- can be directly called using class name

BadAccount acc2 = new BadDepositAccount(); //substitution -- breaks as diff bhvr
BadAccountProcessor.Process(acc2);

WithdrawableAccount acc3 = new GoodSavingsAccount();
GoodAccountProcessor.Process(acc3);

// WithdrawableAccount acc4 = new GoodDepositAccount(); //not supported -- wont break
// GoodAccountProcessor.Process(acc4);
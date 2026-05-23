namespace _25_Q3_ATMmachine
{
    public static class Factory
    {
        public static IDenominationHandler Create()
        {
            var handler100 = new Denomination100();
            var handler200 = new Denomination200();
            var handler500 = new Denomination500();
            var handler2000 = new Denomination2000();

            handler2000.SetNext(handler500).SetNext(handler200).SetNext(handler100);

            return handler2000;
        }
    }
}
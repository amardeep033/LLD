// Software entities should be open for extension for new functionalities but closed for modification(without change in existing src code)
// Problems: Huge method + Hard to test + Every change touches the same file + High risk of breaking existing behavior

using _9_OCP;

BadDiscount bad = new BadDiscount();
double res = bad.GetDiscount("Regular", 1000); 
Console.WriteLine("Bad disc: " + res);

IGoodDiscount disc = new PremiumDiscount(); //lhs is '' -- rhs is ''
GoodDiscount calc = new GoodDiscount();
double result = calc.Calculate(disc, 1000); 
Console.WriteLine("Good disc: " + result);

//-------------------------------------------------------------------------------------------------------------

//But what if different args are needed for different strategy -- Premium Discount requires subs years
//use context(struct with default) -- so new args doesnt break -- nor need to pass something dummy to unused val

DiscountContext ctx = new DiscountContext
{
    Amount = 1000,
    FestivalName = "Diwali"
};

IBestDiscount disc2 = new FestivalDiscount(); //lhs is '' -- rhs is ''
BestDiscount calc2 = new BestDiscount();
double result2 = calc2.Calculate(disc2, ctx); 
Console.WriteLine("Best disc: " + result2);
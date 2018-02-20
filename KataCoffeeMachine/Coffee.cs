namespace KataCoffeeMachine
{
    public class Coffee : Drink
    {
        public Coffee()
        {
            Code = 'C';
            Price = 0.6;
            DrinkType = DrinksAvailable.Coffee;
        }
    }
}
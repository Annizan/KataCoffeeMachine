namespace KataCoffeeMachine
{
    public abstract class Drink
    {
        public double Price { get; protected set; }

        public char Code { get; protected set; }

        public DrinksAvailable DrinkType { get; protected set; }
    }
}

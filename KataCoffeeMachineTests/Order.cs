namespace KataCoffeeMachineTests
{
    public class Order
    {
        public Order(DrinksAvailable drink, int nbSugar)
        {
            this.Drink = drink;
            this.NbSugar = nbSugar;
        }

        public Order(DrinksAvailable drink, int nbSugar, double moneyGiven) : this(drink, nbSugar)
        {
            MoneyGiven = moneyGiven;
        }

        public double MoneyGiven { get; }

        public int NbSugar { get; }

        public DrinksAvailable Drink { get; }
    }
}
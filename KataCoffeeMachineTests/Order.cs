namespace KataCoffeeMachineTests
{
    public class Order
    {
        public Order(DrinksAvailable drink, int nbSugar)
        {
            this.Drink = drink;
            this.NbSugar = nbSugar;
        }

        public int NbSugar { get; }

        public DrinksAvailable Drink { get; }
    }
}
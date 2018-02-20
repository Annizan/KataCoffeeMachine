namespace KataCoffeeMachine
{
    public class Order
    {
        private DrinksAvailable coffee;
        private int v1;
        private double v2;
        private bool v3;

        public Order(DrinksAvailable drink, int nbSugar)
        {
            this.Drink = drink;
            this.NbSugar = nbSugar;
        }

        public Order(DrinksAvailable drink, int nbSugar, double moneyGiven) : this(drink, nbSugar)
        {
            MoneyGiven = moneyGiven;
        }

        public Order(DrinksAvailable drink, int nbSugar, double moneyGiven, bool isExtraHot) : this(drink, nbSugar, moneyGiven)
        {
            IsExtraHot = isExtraHot;
        }

        public bool IsExtraHot { get; }

        public double MoneyGiven { get; }

        public int NbSugar { get; }

        public DrinksAvailable Drink { get; }
    }
}
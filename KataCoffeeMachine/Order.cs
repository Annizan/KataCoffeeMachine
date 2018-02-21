namespace KataCoffeeMachine
{
    public class Order
    {
        public Order(Drink drink, int nbSugar)
        {
            this.Drink = drink;
            this.NbSugar = nbSugar;
        }

        public Order(Drink drink, int nbSugar, double moneyGiven) : this(drink, nbSugar)
        {
            MoneyGiven = moneyGiven;
        }

        public Order(Drink drink, int nbSugar, double moneyGiven, bool isExtraHot) : this(drink, nbSugar, moneyGiven)
        {
            IsExtraHot = isExtraHot;
        }

        public bool IsExtraHot { get; }

        public double MoneyGiven { get; }

        public int NbSugar { get; }

        public Drink Drink { get; }
    }
}
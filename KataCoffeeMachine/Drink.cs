using System;

namespace KataCoffeeMachine
{
    public abstract class Drink
    {
        public double Price { get; protected set; }

        public char Code { get; protected set; }

        public DrinksAvailable DrinkType { get; protected set; }

        public bool IsEnoughMoneyInsert(double moneyGiven)
        {
            return moneyGiven >= Price;
        }

        public double HowMuchIsMissing(double moneyGiven)
        {
            return Price - moneyGiven;
        }

        public override bool Equals(object obj)
        {
            return obj is Drink drink &&
                   Code == drink.Code;
        }

        public override int GetHashCode()
        {
            return -434485196 + Code.GetHashCode();
        }
    }
}

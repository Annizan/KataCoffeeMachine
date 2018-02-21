using System;

namespace KataCoffeeMachine
{
    public class Chocolate : Drink
    {
        public Chocolate()
        {
            Code = 'H';
            Price = 0.5;
            DrinkType = DrinksAvailable.Chocolate;
        }

    }
}
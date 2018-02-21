using System;

namespace KataCoffeeMachine
{
    public class Tea : Drink

    {
        public Tea()
        {
            this.Code = 'T';
            Price = 0.4;
            DrinkType = DrinksAvailable.Tea;
        }
    }
}

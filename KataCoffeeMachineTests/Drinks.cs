using System.Collections.Generic;
using KataCoffeeMachine;
using KataCoffeeMachine.Drinks;

namespace KataCoffeeMachineTests
{
    public class Drinks
    {
        public Drinks()
        {
            DrinksAvailable.Add(new Tea());
            DrinksAvailable.Add(new Coffee());
            DrinksAvailable.Add(new Chocolate());
        }

        public List<Drink> DrinksAvailable { get; }
    }
}
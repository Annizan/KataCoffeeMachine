using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KataCoffeeMachineTests
{
    public class CoffeeMachine
    {
        private List<Drink> drinks;
        public CoffeeMachine()
        {
            drinks = new List<Drink>
            {
                new Tea(),
                new Coffee(),
                new Chocolate()
            };
        }

        public string GetCodeToSend(Order order)
        {
            var drinkOredered = drinks.Find(u => u.DrinkType == order.Drink);
            if (order.MoneyGiven < drinkOredered.Price && order.MoneyGiven > 0)
            {
                var difference = drinkOredered.Price - order.MoneyGiven;
                return GetMessageToSend($"Not enough money, {difference} missing.");
            }

            var code = new StringBuilder();
            code.Append($"{drinks.Find(u => u.DrinkType == order.Drink).Code}:");
            code.Append(order.NbSugar > 0 ? $"{order.NbSugar}:0" : ":");
            
            return code.ToString();
        }

        public string GetMessageToSend(string message)
        {
            return $"M:{message}";
        }
    }

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
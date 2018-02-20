using System;
using System.Collections.Generic;
using System.Text;

namespace KataCoffeeMachine
{
    public class CoffeeMachine
    {
        private readonly List<Drink> drinks;

        private readonly SellsRegister sellRegister;

        public CoffeeMachine()
        {
            sellRegister = new SellsRegister();
            drinks = new List<Drink>
            {
                new Tea(),
                new Coffee(),
                new Chocolate(),
                new Orange()
            };
        }

        public CoffeeMachine(SellsRegister sellRegister)
        {
            this.sellRegister = sellRegister;
            drinks = new List<Drink>
            {
                new Tea(),
                new Coffee(),
                new Chocolate(),
                new Orange()
            };
        }

        public string GetCodeToSend(Order order)
        {

            var drinkOredered = drinks.Find(u => u.DrinkType == order.Drink);
            if (IsEnoughMoneyInsert(order, drinkOredered))
            {

                var code = new StringBuilder();
                code.Append($"{drinks.Find(u => u.DrinkType == order.Drink).Code}");
                if (order.IsExtraHot)
                    code.Append("h");
                code.Append(":");
                code.Append(order.NbSugar > 0 ? $"{order.NbSugar}:0" : ":");

                sellRegister.AddSell(drinkOredered.DrinkType);

                return code.ToString();

            }

            var difference = drinkOredered.Price - order.MoneyGiven;
            return GetMessageToSend($"Not enough money, {difference} missing.");
        }

        private static bool IsEnoughMoneyInsert(Order order, Drink drinkOredered)
        {
            return order.MoneyGiven >= drinkOredered.Price;
        }

        public string GetMessageToSend(string message)
        {
            return $"M:{message}";
        }

        public string GetNumberSell(DrinksAvailable drink)
        {
            return sellRegister.GetNumberSell(drink);
        }

        public string GetGlobalSells()
        {
            return sellRegister.GetGlobalSells();
        }

        public string GetBenefits()
        {
            //double benefits = 0;
            //foreach (DrinksAvailable drinkType in Enum.GetValues(typeof(DrinksAvailable)))
            //{
            //    benefits += sellshistory[drinkType] * drinks.Find(u => u.DrinkType == drinkType).Price;
            //}

            //return benefits.ToString();
            return sellRegister.GetBenefits(drinks);
        }
    }
    
}
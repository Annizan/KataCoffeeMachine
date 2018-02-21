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
            var drink = order.Drink;

            if (drink.IsEnoughMoneyInsert(order.MoneyGiven))
            {
                var code = new StringBuilder();
                code.Append($"{drink.Code}");
                if (order.IsExtraHot)
                    code.Append("h");
                code.Append(":");
                code.Append(order.NbSugar > 0 ? $"{order.NbSugar}:0" : ":");

                sellRegister.AddSell(drink);

                return code.ToString();

            }

            var difference = drink.HowMuchIsMissing(order.MoneyGiven);
            return GetMessageToSend($"Not enough money, {difference} missing.");
        }

        public string GetMessageToSend(string message)
        {
            return $"M:{message}";
        }

        public string GetNumberSell(Drink drink)
        {
            return sellRegister.GetNumberSell(drink);
        }

        public string GetGlobalSells()
        {
            return sellRegister.GetGlobalSells();
        }

        public string GetBenefits()
        {
            return sellRegister.GetBenefits(drinks);
        }
    }
    
}
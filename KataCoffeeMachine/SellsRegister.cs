using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCoffeeMachine
{
    public class SellsRegister
    {
        private readonly Dictionary<Drink, int> sellshistory = new Dictionary<Drink, int>
        {
            {new Tea(), 0},
            {new Chocolate(), 0 },
            {new Coffee(), 0 },
            {new Orange(), 0 }
        };

        public string GetNumberSell(Drink drink)
        {
            return sellshistory[drink].ToString();
        }

        public string GetGlobalSells()
        {
            var globalSells = new StringBuilder();
            foreach (var drinkSells in sellshistory)
            {
                globalSells.Append($"{drinkSells.Key.Code}: {drinkSells.Value}, ");
            }

            return globalSells.ToString();
        }

        public void AddSell(Drink drinkType)
        {
            sellshistory[drinkType]++;
        }

        public string GetBenefits(List<Drink> drinks)
        {
            double benefits = 0;
            foreach (var drinkType in sellshistory)
            {
                benefits += drinkType.Value * drinkType.Key.Price;
            }

            return benefits.ToString();
        }
    }
}

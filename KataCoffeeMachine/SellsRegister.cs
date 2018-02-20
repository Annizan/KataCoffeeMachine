using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCoffeeMachine
{
    public class SellsRegister
    {
        private readonly Dictionary<DrinksAvailable, int> sellshistory = new Dictionary<DrinksAvailable, int>
        {
            {DrinksAvailable.Tea, 0},
            {DrinksAvailable.Chocolate, 0 },
            {DrinksAvailable.Coffee, 0 },
            {DrinksAvailable.Orange, 0 }
        };

        public string GetNumberSell(DrinksAvailable drink)
        {
            return sellshistory[drink].ToString();
        }

        public string GetGlobalSells()
        {
            var globalSells = new StringBuilder();
            foreach (DrinksAvailable drinkType in Enum.GetValues(typeof(DrinksAvailable)))
            {
                globalSells.Append($"{drinkType}: {sellshistory[drinkType]} ");
            }

            return globalSells.ToString();
        }

        public void AddSell(DrinksAvailable drinkType)
        {
            sellshistory[drinkType]++;
        }

        public string GetBenefits(List<Drink> drinks)
        {
            double benefits = 0;
            foreach (DrinksAvailable drinkType in Enum.GetValues(typeof(DrinksAvailable)))
            {
                benefits += sellshistory[drinkType] * drinks.Find(u => u.DrinkType == drinkType).Price;
            }

            return benefits.ToString();
        }
    }
}

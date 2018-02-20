using System.Collections.Generic;
using System.Text;

namespace KataCoffeeMachineTests
{
    public class CoffeeMachine
    {
        private readonly Dictionary<DrinksAvailable,char> drinkToCodeDictionary = new Dictionary<DrinksAvailable, char>
        {
            {DrinksAvailable.Chocolate, 'H'},
            {DrinksAvailable.Tea, 'T'},
            {DrinksAvailable.Coffee, 'C' }
        };
        public string GetCodeToSend(Order order)
        {
            var code = new StringBuilder();
            code.Append($"{drinkToCodeDictionary[order.Drink]}:");
            code.Append(order.NbSugar > 0 ? $"{order.NbSugar}:0" : ":");
            
            return code.ToString();
        }
    }
}
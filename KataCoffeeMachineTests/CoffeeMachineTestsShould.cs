using System.Collections.Generic;
using System.Text;
using NFluent;
using NUnit.Framework;

namespace KataCoffeeMachineTests
{
    public class CoffeeMachineTestsShould
    {
        [Test]
        public void Give_The_Code_For_A_Tea_With_1_Sugar_And_A_Stick()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            Check.That(coffeeMachine.GetCodeToSend(new Order("Tea", 1, true))).IsEqualTo("T:1:0");
        }

        [Test]
        public void Give_The_Code_For_A_Chcolate()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            Check.That(coffeeMachine.GetCodeToSend(new Order("Chocolate", 0, false))).IsEqualTo("H::");
        }

        [Test]
        public void Give_The_Code_For_A_Coffe_2Sugars_Stick()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            Check.That(coffeeMachine.GetCodeToSend(new Order("Coffee", 2, true))).IsEqualTo("C:2:0");
        }
    }

    public class CoffeeMachine
    {
        private readonly Dictionary<string,char> drinkToCodeDictionary = new Dictionary<string, char>
        {
            {"Chocolate", 'H'},
            {"Tea", 'T'},
            {"Coffee", 'C' }
        };
        public string GetCodeToSend(Order order)
        {
            var code = new StringBuilder();
            code.Append($"{drinkToCodeDictionary[order.Drink]}:");
            if(order.NbSugar>0)
                code.Append($"{order.NbSugar}");
            code.Append(":");
            if (order.IsAStickNeeded)
                code.Append("0");

            return code.ToString();
        }
    }

    public class Order
    {
        public Order(string drink, int nbSugar, bool isAStickNeeded)
        {
            this.Drink = drink;
            this.NbSugar = nbSugar;
            this.IsAStickNeeded = isAStickNeeded;
        }

        public bool IsAStickNeeded { get; }

        public int NbSugar { get; }

        public string Drink { get; }
    }
}

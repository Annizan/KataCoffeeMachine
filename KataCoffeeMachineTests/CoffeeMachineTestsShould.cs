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
            Check.That(coffeeMachine.GetCodeToSend(new Order(DrinksAvailable.Tea, 1))).IsEqualTo("T:1:0");
        }

        [Test]
        public void Give_The_Code_For_A_Chcolate()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            Check.That(coffeeMachine.GetCodeToSend(new Order(DrinksAvailable.Chocolate, 0))).IsEqualTo("H::");
        }

        [Test]
        public void Give_The_Code_For_A_Coffe_2Sugars_Stick()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            Check.That(coffeeMachine.GetCodeToSend(new Order(DrinksAvailable.Coffee, 2))).IsEqualTo("C:2:0");
        }

        [Test]
        public void Give_The_Message_To_Show_To_The_Customer()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            Check.That(coffeeMachine.GetMessageToSend("Cela ne fonctionnera pas!")).IsEqualTo("M:Cela ne fonctionnera pas!");
        }
    }
}

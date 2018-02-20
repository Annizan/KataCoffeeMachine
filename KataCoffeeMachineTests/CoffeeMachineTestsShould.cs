using KataCoffeeMachine;
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
            var order = new Order(DrinksAvailable.Tea, 1, 10);
            Check.That(coffeeMachine.GetCodeToSend(order)).IsEqualTo("T:1:0");
        }

        [Test]
        public void Give_The_Code_For_A_Chcolate()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            var order = new Order(DrinksAvailable.Chocolate, 0, 10);
            Check.That(coffeeMachine.GetCodeToSend(order)).IsEqualTo("H::");
        }

        [Test]
        public void Give_The_Code_For_A_Coffe_2Sugars_Stick()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            var order = new Order(DrinksAvailable.Coffee, 2, 10);
            Check.That(coffeeMachine.GetCodeToSend(order)).IsEqualTo("C:2:0");
        }

        [Test]
        public void Give_The_Message_To_Show_To_The_Customer()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            Check.That(coffeeMachine.GetMessageToSend("Cela ne fonctionnera pas!")).IsEqualTo("M:Cela ne fonctionnera pas!");
        }

        // Second Iteration

        [Test]
        public void Give_An_Error_Message_If_Not_Enough_Money_For_Tea()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            var order = new Order(DrinksAvailable.Tea, 0, 0.3);
            Check.That(coffeeMachine.GetCodeToSend(order))
                .IsEqualTo("M:Not enough money, 0,1 missing.");
        }

        [Test]
        public void Give_An_Error_Message_If_Not_Enough_Money_For_Coffee()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            var order = new Order(DrinksAvailable.Coffee, 0, 0.5);
            Check.That(coffeeMachine.GetCodeToSend(order))
                .IsEqualTo("M:Not enough money, 0,1 missing.");
        }


        // Third iteration

        [Test]
        public void Give_An_Orange_Juice()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            var order = new Order(DrinksAvailable.Orange, 0, 0.6);
            Check.That(coffeeMachine.GetCodeToSend(order)).IsEqualTo("O::");
        }

        [Test]
        public void Give_A_Hot_Coffee_With_One_Sugar()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            var order = new Order(DrinksAvailable.Coffee, 1, 0.6, true);
            Check.That(coffeeMachine.GetCodeToSend(order)).IsEqualTo("Ch:1:0");
        }

        [Test]
        public void Give_A_Hot_Tea_With_Two_Sugars()
        {
            var coffeMachine = new CoffeeMachine();
            var order = new Order(DrinksAvailable.Tea, 2, 0.6, true);
            Check.That(coffeMachine.GetCodeToSend(order)).IsEqualTo("Th:2:0");
        }

    }
}

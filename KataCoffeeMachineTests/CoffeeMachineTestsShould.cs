using KataCoffeeMachine;
using KataCoffeeMachine.Drinks;
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
        public void Give_A_Extra_Hot_Coffee_With_One_Sugar()
        {
            CoffeeMachine coffeeMachine = new CoffeeMachine();
            var order = new Order(DrinksAvailable.Coffee, 1, 0.6, true);
            Check.That(coffeeMachine.GetCodeToSend(order)).IsEqualTo("Ch:1:0");
        }

        [Test]
        public void Give_A_Extra_Hot_Tea_With_Two_Sugars()
        {
            var coffeeMachine = new CoffeeMachine();
            var order = new Order(DrinksAvailable.Tea, 2, 0.6, true);
            Check.That(coffeeMachine.GetCodeToSend(order)).IsEqualTo("Th:2:0");
        }

        // Fourth Iteration

        [Test]
        public void Give_The_Number_Of_Coffee_Sell()
        {
            var coffeeMachine = new CoffeeMachine();

            var order = new Order(DrinksAvailable.Coffee, 1, 0.6, true);
            var order1 = new Order(DrinksAvailable.Coffee, 1, 0.6, true);
            var order2= new Order(DrinksAvailable.Coffee, 1, 0.6, true);
            coffeeMachine.GetCodeToSend(order);
            coffeeMachine.GetCodeToSend(order1);
            coffeeMachine.GetCodeToSend(order2);
            Check.That(coffeeMachine.GetNumberSell(DrinksAvailable.Coffee)).IsEqualTo("3");
        }

        [Test]
        public void Give_The_Number_Of_tea_Sell()
        {
            var coffeeMachine = new CoffeeMachine();

            var order = new Order(DrinksAvailable.Tea, 1, 0.6, true);
            var order1 = new Order(DrinksAvailable.Chocolate, 1, 0.6, true);
            var order2 = new Order(DrinksAvailable.Tea, 1, 0.6, true);
            coffeeMachine.GetCodeToSend(order);
            coffeeMachine.GetCodeToSend(order1);
            coffeeMachine.GetCodeToSend(order2);
            Check.That(coffeeMachine.GetNumberSell(DrinksAvailable.Tea)).IsEqualTo("2");
        }

        [Test]
        public void Give_The_Number_Of_Sells()
        {
            var coffeeMachine = new CoffeeMachine();

            var order = new Order(DrinksAvailable.Tea, 1, 0.6, true);
            var order1 = new Order(DrinksAvailable.Chocolate, 1, 0.6, true);
            var order3 = new Order(DrinksAvailable.Tea, 1, 0.6, true);
            var order4 = new Order(DrinksAvailable.Chocolate, 1, 0.6, true);
            var order5 = new Order(DrinksAvailable.Orange, 1, 0.6, true);
            var order6 = new Order(DrinksAvailable.Orange, 1, 0.6, true);
            var order7 = new Order(DrinksAvailable.Coffee, 1, 0.6, true);
            var order2 = new Order(DrinksAvailable.Tea, 1, 0.6, true);
            coffeeMachine.GetCodeToSend(order);
            coffeeMachine.GetCodeToSend(order1);
            coffeeMachine.GetCodeToSend(order2);
            coffeeMachine.GetCodeToSend(order3);
            coffeeMachine.GetCodeToSend(order4);
            coffeeMachine.GetCodeToSend(order5);
            coffeeMachine.GetCodeToSend(order6);
            coffeeMachine.GetCodeToSend(order7);
            Check.That(coffeeMachine.GetGlobalSells()).IsEqualTo("Chocolate: 2 Coffee: 1 Orange: 2 Tea: 3 ");
        }

        [Test]
        public void Give_The_Benefits()
        {
            var coffeeMachine = new CoffeeMachine();

            var order = new Order(DrinksAvailable.Tea, 1, 0.6, true);
            var order1 = new Order(DrinksAvailable.Chocolate, 1, 0.6, true);
            var order3 = new Order(DrinksAvailable.Tea, 1, 0.6, true);
            var order4 = new Order(DrinksAvailable.Chocolate, 1, 0.6, true);
            var order5 = new Order(DrinksAvailable.Orange, 1, 0.6, true);
            var order6 = new Order(DrinksAvailable.Orange, 1, 0.6, true);
            var order7 = new Order(DrinksAvailable.Coffee, 1, 0.6, true);
            var order2 = new Order(DrinksAvailable.Tea, 1, 0.6, true);
            coffeeMachine.GetCodeToSend(order);
            coffeeMachine.GetCodeToSend(order1);
            coffeeMachine.GetCodeToSend(order2);
            coffeeMachine.GetCodeToSend(order3);
            coffeeMachine.GetCodeToSend(order4);
            coffeeMachine.GetCodeToSend(order5);
            coffeeMachine.GetCodeToSend(order6);
            coffeeMachine.GetCodeToSend(order7);
            Check.That(coffeeMachine.GetBenefits()).IsEqualTo("4");
        }
    }
}

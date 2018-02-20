using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCoffeeMachineTests
{
    public abstract class Drink
    {
        public double Price { get; protected set; }

        public char Code { get; protected set; }

        public DrinksAvailable DrinkType { get; protected set; }
    }
}

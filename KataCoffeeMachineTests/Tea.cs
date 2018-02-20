using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KataCoffeeMachineTests
{
    public class Tea : Drink

    {
        public Tea()
        {
            this.Code = 'T';
            Price = 0.4;
            DrinkType = DrinksAvailable.Tea;
        }
    }
}

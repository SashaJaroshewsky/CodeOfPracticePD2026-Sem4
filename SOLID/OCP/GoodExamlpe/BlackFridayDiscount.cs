using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCP.GoodExamlpe
{
    internal class BlackFridayDiscount : IDiscount
    {
        public decimal ApplyDiscount(decimal total)
        {
            return total * 0.7m;
        }
    }
    
}

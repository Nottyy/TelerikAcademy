using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesignPattern
{
    public class ChocolateIceCream : IIceCream
    {
        public string Functionality()
        {
            return "Chocolate Ice cream";
        }
    }
}

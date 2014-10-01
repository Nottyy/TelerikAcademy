using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesignPattern
{
    public class VanillaIceCream : IIceCream
    {
        public string Functionality()
        {
            return "Vanilla Ice cream";
        }
    }
}

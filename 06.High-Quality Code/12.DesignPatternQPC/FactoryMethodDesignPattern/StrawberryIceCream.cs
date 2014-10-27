using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesignPattern
{
    public class StrawberryIceCream : IIceCream
    {
        public string Functionality()
        {
            return "Strawberry Ice cream";
        }
    }
}

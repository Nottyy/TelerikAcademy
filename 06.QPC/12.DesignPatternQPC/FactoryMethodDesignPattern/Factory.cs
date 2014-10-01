using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodDesignPattern
{
    static class Factory
    {
        /// <summary>
        /// This is the Factory method
        /// </summary>
        public static IIceCream Get(int id)
        {
            switch (id)
            {
                case 0:
                    return new ChocolateIceCream();
                case 1:
                    return new VanillaIceCream();
                case 2:
                    return new StrawberryIceCream();
                default:
                    return null;
            }
        }
    }
}

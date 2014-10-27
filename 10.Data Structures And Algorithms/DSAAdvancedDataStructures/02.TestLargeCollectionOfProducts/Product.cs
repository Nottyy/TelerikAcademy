using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLargeCollectionOfProducts
{
    public class Product : IComparable
    {
        public Product(string name, double price)
        {
            this.Name = name;
            this.Price = price;
        }

        public string Name { get; set; }

        public double Price { get; set; }

        public int CompareTo(object obj)
        {
            Product otherProduct = obj as Product;
            if (this.Price < otherProduct.Price)
            {
                return 1;
            }
            else if (this.Price > otherProduct.Price)
            {
                return -1;
            }

            return 0;
        }

        public override string ToString()
        {
            string result = this.Name + " " +  this.Price;
            return result;
        }
    }
}

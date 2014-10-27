using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeCompany
{
    public class Article : IComparable<Article>
    {
        public Article(string barcode, string vendor, string title, double price)
        {
            this.Barcode = barcode;
            this.Vendor = vendor;
            this.Title = title;
            this.Price = price;
        }

        public string Barcode { get; set; }

        public string Vendor { get; set; }

        public string Title { get; set; }

        public double Price { get; set; }

        public int CompareTo(Article other)
        {
            return this.Barcode.CompareTo(other.Barcode);
        }
        //public int CompareTo(Article article)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

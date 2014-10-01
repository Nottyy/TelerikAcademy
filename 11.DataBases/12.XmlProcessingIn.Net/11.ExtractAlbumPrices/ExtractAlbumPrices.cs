using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml;

namespace ExtractAlbumPrices
{
    public class ExtractAlbumPrices
    {
        public static void Main()
        {
            var doc = new XmlDocument();
            doc.Load("..\\..\\..\\XmlCatalogDirectory\\text.xml");

            Dictionary<string, decimal> albumPrices = new Dictionary<string,decimal>();

            string xpath = "catalogue/artist/album";
            var albums = doc.SelectNodes(xpath);

            foreach (XmlNode album in albums)
            {
                string name = album["name"].InnerText;
                decimal price = decimal.Parse(album["price"].InnerText);
                int year = int.Parse(album["year"].InnerText);

                if (DateTime.Now.Year - 5 <= year)
                {
                    albumPrices.Add(name, price);
                }
            }

            Console.WriteLine("Prices for all albums, published 5 years ago or earlier.\n");
            foreach (var album in albumPrices)
            {
                Console.WriteLine("{0} -> {1}$", album.Key, album.Value);
            }
        }
    }
}

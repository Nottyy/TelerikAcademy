using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ExtractAlbumPricesWihLinqQuery
{
    public class Program
    {
        public static void Main(string[] args)
        {
            XDocument doc = XDocument.Load("..\\..\\..\\XmlCatalogDirectory\\text.xml");
            int currentYear = DateTime.Now.Year;

            var albums = doc.Descendants("album")
                    .Select(x => new
                    {
                        Name = x.Element("name").Value,
                        Price = x.Element("price").Value,
                        Year = x.Element("year").Value

                    })
                    .Where(x => int.Parse(x.Year) >= currentYear - 5);

            Console.WriteLine("Prices for all albums, published 5 years ago or earlier.\n");
            foreach (var album in albums)
            {
                Console.WriteLine("{0} -> {1}$", album.Name, album.Price);
            }
        }
    }
}

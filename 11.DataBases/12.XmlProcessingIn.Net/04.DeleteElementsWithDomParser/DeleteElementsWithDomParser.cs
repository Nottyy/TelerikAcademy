using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DeleteElementsWithDomParser
{
    public class DeleteElementsWithDomParser
    {
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("..\\..\\..\\XmlCatalogDirectory\\text.xml");

            var root = doc.DocumentElement;

            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
                XmlNode artist = root.ChildNodes[i];

                for (int j = 0; j < artist.ChildNodes.Count; j++)
                {
                    XmlNode album = artist.ChildNodes[j];

                    if (decimal.Parse(album["price"].InnerText) > 18.0m)
                    {
                        artist.RemoveChild(album);
                        Console.WriteLine("Successfully removed album.");
                    }
                }
            }

            doc.Save("..\\..\\removed.xml");
        }
    }
}

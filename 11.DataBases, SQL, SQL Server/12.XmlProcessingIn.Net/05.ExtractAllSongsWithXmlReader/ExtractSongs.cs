using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ExtractAllSongsWithXmlReader
{
    public class ExtractSongs
    {
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("..\\..\\..\\XmlCatalogDirectory\\text.xml");

            using (XmlReader reader = XmlReader.Create("..\\..\\..\\XmlCatalogDirectory\\text.xml"))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "title")
                    {
                        Console.WriteLine(reader.ReadElementContentAsString());
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace FromXmlToOtherXml
{
    public class ExtractCatalogue
    {
        public static void Main()
        {
            XmlReader reader = XmlReader.Create("..\\..\\..\\XmlCatalogDirectory\\text.xml");
            XmlTextWriter  writer = new XmlTextWriter("..\\..\\album.xml",Encoding.UTF8);

            using (writer)
            {
                writer.WriteStartDocument();
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;
                writer.WriteStartElement("albums");

                string artist = "";
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "artist")
                    {
                        artist = reader.GetAttribute("name");
                    }
                    else if ((reader.NodeType == XmlNodeType.Element) && reader.Name == "name")
                    {
                        string albumName = reader.ReadElementContentAsString();

                        writer.WriteStartElement("album");
                        writer.WriteElementString("name", albumName);
                        writer.WriteElementString("artist", artist);
                        writer.WriteEndElement();
                    }
                }
            }
        }
    }
}

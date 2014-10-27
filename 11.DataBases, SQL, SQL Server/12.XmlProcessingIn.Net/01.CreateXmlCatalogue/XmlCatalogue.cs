using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace CreateXmlCatalogue
{
    public class XmlCatalogue
    {
        public static void Main()
        {
            XElement catalogue = new XElement("catalogue");
            XNamespace ns = "DefaultNameSpace";
            catalogue.SetAttributeValue("type", "catalogue");

            string[] artists = new string[10] { "BTR", "Eminem", "GunsNRoses", "WhiteSnake", "Metallica", "DefLeppard", "Eminem", "BTR", "DeepPurple", "AC/DC"};

            for (int i = 0; i < 10; i++)
            {
                decimal price = 10.3m;
                CreateAlbum(ns, catalogue, "Igrata" + i, artists[i], 2005 + i, artists[i], price + i, "Zlatna Ribka" + i, "3.05");
            }

            catalogue.Save("..\\..\\..\\XmlCatalogDirectory\\text.xml");
        }

        private static void CreateAlbum(XNamespace ns, XElement catalogue, string albumName, string artistName, int year, string producer, decimal price, string songTitle, string duration)
        {
            var artist = new XElement("artist");
            artist.SetAttributeValue("name", artistName);

            var album = new XElement("album");
            album.Add(new XElement("name", albumName));
            album.Add(new XElement("year", year));
            album.Add(new XElement("producer", producer));
            album.Add(new XElement("price", price));

            var songs = new XElement("songs");
            songs.Add(new XElement("title", songTitle));
            songs.Add(new XElement("duration", duration));

            album.Add(songs);
            artist.Add(album);
            catalogue.Add(artist);
        }
    }
}

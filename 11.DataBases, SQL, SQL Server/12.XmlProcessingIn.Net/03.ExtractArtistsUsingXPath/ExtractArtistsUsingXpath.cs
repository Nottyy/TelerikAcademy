using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ExtractArtistsUsingXPath
{
    public class ExtractArtistsUsingXpath
    {
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("..\\..\\..\\XmlCatalogDirectory\\text.xml");

            string xPath = "catalogue/artist";
            var albums = doc.SelectNodes(xPath);

            Dictionary<string, int> artistsAlbumsCount = new Dictionary<string, int>();

            foreach (XmlNode prop in albums)
            {
                var artistName = prop.Attributes["name"].Value;
                var albumsCount = prop.ChildNodes.Count;

                if (!artistsAlbumsCount.ContainsKey(artistName))
                {
                    artistsAlbumsCount.Add(artistName, albumsCount);
                }
                else
                {
                    artistsAlbumsCount[artistName] += albumsCount;
                }
            }

            foreach (var artist in artistsAlbumsCount)
            {
                Console.WriteLine("{0} -> {1} albums", artist.Key, artist.Value);
            }
        }
    }
}

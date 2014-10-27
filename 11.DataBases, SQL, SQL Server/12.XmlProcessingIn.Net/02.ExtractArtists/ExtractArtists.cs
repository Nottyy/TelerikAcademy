using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace ExtractArtists
{
    public class ExtractArtists
    {
        public static void Main()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("..\\..\\..\\XmlCatalogDirectory\\text.xml");

            XmlNode root = doc.DocumentElement;
            Dictionary<string, int> artistsAlbumsCount = new Dictionary<string, int>();

            foreach (XmlNode artist in root.ChildNodes)
            {
                var currentArtistName = artist.Attributes["name"].Value;
                var albumsCount = artist.ChildNodes.Count;

                if (!artistsAlbumsCount.ContainsKey(currentArtistName))
                {
                    artistsAlbumsCount.Add(currentArtistName, albumsCount);
                }
                else
                {
                    artistsAlbumsCount[currentArtistName] += albumsCount;
                }
            }

            foreach (var artist in artistsAlbumsCount)
            {
                Console.WriteLine("{0} -> {1} albums", artist.Key, artist.Value);
            }
        }
    }
}

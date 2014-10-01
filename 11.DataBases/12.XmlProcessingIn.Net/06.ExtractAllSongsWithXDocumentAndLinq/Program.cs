using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExtractAllSongsWithXDocumentAndLinq
{
    public class Program
    {
        public static void Main()
        {
            XDocument doc = XDocument.Load("..\\..\\..\\XmlCatalogDirectory\\text.xml");

            var songTitles = doc.Descendants("songs")
                            .Select(s => new { title = s.Element("title").Value });

            foreach (var song in songTitles)
            {
                Console.WriteLine(song.title);
            }
        }
    }
}

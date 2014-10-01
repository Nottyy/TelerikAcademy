using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bookmarks.Model;
using System.Xml.Linq;

namespace Bookmarks.Importer
{
    
    class Program
    {
        static BookmarksEntities db;
        static void Main(string[] args)
        {
            db = new BookmarksEntities();

            ImportXml();
        }

        private static void ImportXml()
        {
            XElement xmlBookmarks = XElement.Load("..\\..\\xmlToImport.xml");
            //Console.WriteLine(xmlBookmarks);

            foreach (var item in xmlBookmarks.Elements("bookmark"))
            {
                
            }
        }
    }
}

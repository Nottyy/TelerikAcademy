using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _10.TraverseDirectoryWithXDocument
{
    public class TraverseDirectory
    {
        static void Main()
        {
            string rootPath = @"E:\My Space\Games";
            var dir = new DirectoryInfo(rootPath);

            var doc = new XDocument(GetDirectoryXml(dir));

            Console.WriteLine(doc.ToString()); // if you want to see it on the console

            doc.Save("../../../10. Directory.xml");
            Console.WriteLine("10. Directory.xml created!");
        }

        public static XElement GetDirectoryXml(DirectoryInfo dir)
        {
            var info = new XElement("dir",
                           new XAttribute("name", dir.Name));

            foreach (var file in dir.GetFiles())
            {
                info.Add(new XElement("file",
                             new XAttribute("name", file.Name)));
            }

            foreach (var subDir in dir.GetDirectories())
            {
                info.Add(GetDirectoryXml(subDir));
            }

            return info;
        }
    }
}

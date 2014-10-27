using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace TransformToHtml
{
    public class Program
    {
        public static void Main()
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../../14.catalog.xslt");
            xslt.Transform("..\\..\\..\\XmlCatalogDirectory\\text.xml", "../../../14. Catalog.html");
            Console.WriteLine("Successfully transformed!");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace _16.GenerateXsdSchema
{
    class Program
    {
        public static void Main()
        {
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add("", "Catalogue.xsd");

            XDocument vadiDocument = XDocument.Load("Catalogue.xml");
            bool errors = false;

            vadiDocument.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });

            Console.WriteLine("First document is {0} valid", errors ? "not" : "");

            //--------------------------------------------------------------

            schemas = new XmlSchemaSet();
            schemas.Add("", "Catalogue.xsd");

            XDocument invalidDocument = XDocument.Load("Catalogue-Copy.xml");
            errors = false;

            invalidDocument.Validate(schemas, (o, e) =>
            {
                Console.WriteLine("{0}", e.Message);
                errors = true;
            });

            Console.WriteLine("Second document is {0} valid", errors ? "not" : "");
        }
    }
}

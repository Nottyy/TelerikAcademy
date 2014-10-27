using System.Xml.Xsl;

public static class XmlToHTML
{
    public static void ConverXmlToHtml()
    {
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(@"..\..\..\XML_export\test.xsl");
        xslt.Transform(@"..\..\..\XML_export\test.xml", @"..\..\..\XML_export\students.html");
    }
}
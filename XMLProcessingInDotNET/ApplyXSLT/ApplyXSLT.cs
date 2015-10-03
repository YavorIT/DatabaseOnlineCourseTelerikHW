
/*
    Write a C# program to apply the XSLT stylesheet transformation on the file catalog.xml using the class XslTransform.
*/

using System.Xml.Xsl;

class ApplyXSLT
{
    static void Main()
    {
        XslCompiledTransform xslt = new XslCompiledTransform();
        xslt.Load(@"..\..\..\catalogue.xslt");
        xslt.Transform(@"..\..\..\catalogue.xml", @"..\..\..\catalogue.html");
    }
}
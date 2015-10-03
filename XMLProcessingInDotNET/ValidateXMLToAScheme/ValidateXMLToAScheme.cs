
/*
    Using Visual Studio generate an XSD schema for the file catalog.xml.
    Write a C# program that takes an XML file and an XSD file (schema) and validates the XML file against the schema.
    Test it with valid XML catalogs and invalid XML catalogs.
*/

using System;
using System.Xml.Linq;
using System.Xml.Schema;
class ValidateXMLToAScheme
{
    static void Main()
    {
        var xmlScheme = new XmlSchemaSet();
        xmlScheme.Add(string.Empty, @"..\..\..\catalogue.xsd");

        XDocument doc = XDocument.Load(@"..\..\..\catalogue.xml");
        XDocument notValidDoc = XDocument.Load(@"..\..\..\notValidCatalogue.xml");

        Console.WriteLine("The valid catalogue XML result:");
        Validate(doc, xmlScheme);
        Console.WriteLine("The notValidCatalogue XML result:");
        Validate(notValidDoc, xmlScheme);
    }

    private static void Validate(XDocument doc, XmlSchemaSet xmlScheme)
    {
        bool notValidated = false;
        doc.Validate(xmlScheme, (eventObject, eventHandler) => { notValidated = true; }, false);

        Console.WriteLine(notValidated ? "Not Validated" : "Validated");
    }
}
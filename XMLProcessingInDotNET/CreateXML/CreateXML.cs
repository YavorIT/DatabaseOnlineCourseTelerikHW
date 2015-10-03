
/*
    In a text file we are given the name, address and phone number of given person (each at a single line).
    Write a program, which creates new XML document, which contains these data in structured XML format.
*/

// I have assumed that the file is written in the exact format
using System.IO;
using System.Xml.Linq;

class CreateXML
{
    static void Main()
    {
        StreamReader reader = new StreamReader(@"..\..\..\PersonInfo.txt");
        string name;
        string address;
        string phoneNumber;
        using (reader)
        {
            name = reader.ReadLine();
            address = reader.ReadLine();
            phoneNumber = reader.ReadLine();
        }

        XElement person = new XElement("persons",
            new XElement("person",
                new XElement("name", name),
                new XElement("address", address),
                new XElement("phone-number", phoneNumber)));

        person.Save(@"..\..\..\Person.xml");
    }   
}
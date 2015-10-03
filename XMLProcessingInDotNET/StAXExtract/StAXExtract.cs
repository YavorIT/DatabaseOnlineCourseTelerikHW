
/*
    Write a program, which using XmlReader extracts all song titles from catalog.xml.
*/

using System;
using System.Xml;

class StAXExtract
{
    static void Main()
    {
        Console.WriteLine("Song titles:");
        int count = 0;
        using (XmlReader reader = XmlReader.Create(@"..\..\..\catalogue.xml"))
        {
            while(reader.Read())
            {
                if(reader.Name == "title")
                {
                    count++;
                    Console.WriteLine("{0}. {1}", count, reader.ReadElementString());
                }
            }
        }
    }
}
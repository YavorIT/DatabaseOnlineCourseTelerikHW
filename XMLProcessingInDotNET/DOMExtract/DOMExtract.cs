
/*
    Write program that extracts all different artists which are found in the catalog.xml.
    For each author you should print the number of albums in the catalogue.
    Use the DOM parser and a hash-table.
*/

using System;
using System.Xml;
using System.Collections.Generic;

class DOMExtract
{
    static void Main(string[] args)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(@"..\..\..\catalogue.xml");
        XmlElement rootNode = doc.DocumentElement;
        var artists = new Dictionary<string, int>();

        foreach (XmlNode node in rootNode.ChildNodes)
        {
            foreach (XmlNode artistNode in node.ChildNodes)
            {
                if (artistNode.Name == "artist")
                {
                    if (!artists.ContainsKey(artistNode.InnerText))
                    {
                        artists.Add(artistNode.InnerText, 1);
                    }
                    else
                    {
                        artists[artistNode.InnerText]++;
                    }
                }
            }
        }

        foreach (var artist in artists)
        {
            Console.WriteLine("{0} - {1}", artist.Key, artist.Value);
        }
    }
}
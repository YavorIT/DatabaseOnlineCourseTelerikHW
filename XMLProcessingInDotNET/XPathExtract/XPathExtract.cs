
/*
    The same as the DOM extract program just using XPath!
*/

using System;
using System.Collections.Generic;
using System.Xml;

class XPathExtract
{
    static void Main(string[] args)
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(@"..\..\..\catalogue.xml");

        var artists = new Dictionary<string, int>();
        string XPath = "/catalogue/album/artist";
        XmlNodeList artistsList = doc.SelectNodes(XPath);

        foreach (XmlNode node in artistsList)
        {
            if(!artists.ContainsKey(node.InnerText))
            {
                artists.Add(node.InnerText, 1);
            }else
            {
                artists[node.InnerText]++;
            }
        }

        foreach (var artist in artists)
        {
            Console.WriteLine("{0} - {1}", artist.Key, artist.Value);
        }
    }
}
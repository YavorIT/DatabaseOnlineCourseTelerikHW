
/*
    The same as the StAX but using LINQ!
*/

using System;
using System.Linq;
using System.Xml.Linq;

class LINQExtract
{
    static void Main()
    {
        XDocument doc = XDocument.Load(@"..\..\..\catalogue.xml");

        var songs =
            from song in doc.Descendants("song")
            select new
            {
                Title = song.Element("title").Value
            };

        Console.WriteLine("Song titles:");
        int count = 0;
        foreach (var songTitle in songs)
        {
            count++;
            Console.WriteLine("{0}. {1}", count, songTitle.Title);
        }
    }
}
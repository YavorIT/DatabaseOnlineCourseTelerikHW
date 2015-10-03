
/*
    Write a program, which extract from the file catalog.xml the prices for all albums, published 5 years ago or earlier.
    Use XPath query.
*/

using System;
using System.Collections.Generic;
using System.Xml;

class ExtractOlderThanFiveYearsXPath
{
    static void Main()
    {
        string fileDir = @"..\..\..\catalogue.xml";
        var prices = new List<double>();
        int currentYear = 2015;

        XmlDocument doc = new XmlDocument();
        doc.Load(fileDir);

        string yearXPath = @"/catalogue/album/year";
        string priceXPath = @"/catalogue/album/price";

        // making two lists. One for the years, 
        //one for the prices so that year's first element is the year of the album with price - price's first element
            XmlNodeList albumsYears = doc.SelectNodes(yearXPath);
            XmlNodeList albumsPrices = doc.SelectNodes(priceXPath);

        double price = 0;
        int year = 0;
        XmlNode currentYearNode;
        XmlNode currentPriceNode;

        for (int i = 0; i < albumsYears.Count; i++)
        {
            currentYearNode = albumsYears[i]; // Gets the current album's year
            currentPriceNode = albumsPrices[i]; // Gets the current album's price

            year = int.Parse(currentYearNode.InnerText);
            price = double.Parse(currentPriceNode.InnerText);

            if (year <= currentYear - 5)
            {
                prices.Add(price);
            }
        }

        //Print the list with the prices
        Print(prices);
    }

    private static void Print(List<double> prices)
    {
        foreach (var price in prices)
        {
            Console.WriteLine(price);
        }
    }
}
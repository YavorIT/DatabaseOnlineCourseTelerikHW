
/*
    The same as the previous but using LINQ
*/

using System;
using System.Linq;
using System.Xml.Linq;

class ExtractOlderThanFiveYearsLINQ
{
    static void Main()
    {
        string documentXML = @"..\..\..\catalogue.xml";
        XDocument doc = XDocument.Load(documentXML);

        int currentYear = 2015;

        // take all albums' years
        var years = from year in doc.Descendants("year")
                    select new
                    {
                        year = int.Parse(year.Value)
                    };

        // take all albums' prices
        var prices = from price in doc.Descendants("price")
                     select new
                     {
                         price = double.Parse(price.Value)
                     };

        // this array will contain a bool value to indicate if the year is before 9currentYear - 5)
        bool[] fiveYearsAgoOrOlder = new bool[years.Count()];

        int i = 0;

        // see which years to use
        foreach (var year in years)
        {
            if (year.year <= currentYear - 5)
            {
                fiveYearsAgoOrOlder[i] = true;
            }
            i++;
        }

        i = 0;
        // print the prices of the albums which release year is before (currentYear - 5) 
        foreach (var price in prices)
        {
            if(fiveYearsAgoOrOlder[i])
            {
                Console.WriteLine(price.price);
            }
            i++;
        }
    }
}

/*
    Same as the previous using LINQ
*/

using System;
using System.IO;
using System.Xml.Linq;

class TraverseDirectoryLINQ
{
    static void Main()
    {
        string directory = @"..\..\..\TraverseDirectoryLINQ";
        string writeXmlFileDir = @"..\..\..\directoryLINQ.xml";

        var TraverseDirectoryLINQ = collapseAll(directory);

        TraverseDirectoryLINQ.Save(writeXmlFileDir);
    }

    private static XElement collapseAll(string directory)
    {
        XElement newElement = new XElement("dir", new XAttribute("path", directory.TrimStart('.', '\\')));
        foreach (var dir in Directory.GetDirectories(directory))
        {
            newElement.Add(collapseAll(dir));
        }

        foreach (var file in Directory.GetFiles(directory))
        {
            newElement.Add(new XElement("file",
                         new XAttribute("name", file.Substring(file.LastIndexOf('\\') + 1))));
        }

        return newElement;
    }
}
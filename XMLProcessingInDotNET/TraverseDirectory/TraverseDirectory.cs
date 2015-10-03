
/*
    Write a program to traverse given directory and write to a XML file its contents
    together with all subdirectories and files.

    Use tags <file> and <dir> with appropriate attributes.
    For the generation of the XML document use the class XmlWriter.
*/

using System.IO;
using System.Text;
using System.Xml;

class TraverseDirectory
{
    static void Main()
    {
        string directory = @"..\..\..\TraverseDirectory";
        string writeXmlFileDir = @"..\..\..\directory.xml";
        Encoding encoding = Encoding.GetEncoding("utf-8");

        using (XmlTextWriter writer = new XmlTextWriter(writeXmlFileDir, encoding))
        {
            writer.WriteStartDocument();
            writer.WriteStartElement("TraverseDirectory");
            collapseAll(writer, directory);
        }
    }

    private static void collapseAll(XmlTextWriter writer, string directory)
    {
        foreach (var dir in Directory.GetDirectories(directory))
        {
            writer.WriteStartElement("dir");
            writer.WriteAttributeString("path", directory.TrimStart('.', '\\'));
            collapseAll(writer, dir);     // using recursion to expand and search in all subfolders
            writer.WriteEndElement();
        }

        foreach (var file in Directory.GetFiles(directory))
        {
            writer.WriteStartElement("file");
            writer.WriteAttributeString("name", file.Substring(file.LastIndexOf('\\') + 1)); //using the Substring() method
            writer.WriteEndElement();                                                        //to remove the file path and 
                                                                                             //write only the name of the file
        }
    }
}
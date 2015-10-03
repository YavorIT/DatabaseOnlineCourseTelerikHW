
/*
    Write a program, which (using XmlReader and XmlWriter) reads the file catalog.xml
    and creates the file album.xml,
    in which stores in appropriate way the names of all albums and their authors.
*/

using System.Collections.Generic;
using System.Text;
using System.Xml;

class StAXReadCreateXML
{
    static void Main()
    {
        var albumsAuthors = new Dictionary<string, string>();
        string nameOfAlbum = string.Empty;
        string artistName = string.Empty;
        bool inAlbum = false;
        using (XmlReader reader = XmlReader.Create(@"..\..\..\catalogue.xml"))
        {
            while(reader.Read())
            {
                if(reader.Name == "album" && reader.NodeType == XmlNodeType.Element)
                {
                    inAlbum = true;
                }

                if(reader.Name == "album" && reader.NodeType == XmlNodeType.EndElement)
                {
                    albumsAuthors.Add(nameOfAlbum, artistName);
                    inAlbum = false;
                }

                if (inAlbum)
                {
                    if (reader.Name == "name")
                    {
                        nameOfAlbum = reader.ReadElementString();
                    }

                    if(reader.Name == "artist")
                    {
                        artistName = reader.ReadElementString();
                    }
                }
            }
        }

        string fileName = @"..\..\..\album.xml";
        Encoding encoding = Encoding.GetEncoding("utf-8");
        using (XmlTextWriter writer = new XmlTextWriter(fileName, encoding))
        {
            writer.Formatting = Formatting.Indented;
            writer.IndentChar = '\t';
            writer.Indentation = 1;

            writer.WriteStartDocument();
            writer.WriteStartElement("albums");
            foreach (var album in albumsAuthors)
            {
                WriteAlbum(writer, album.Key, album.Value);
            }
            writer.WriteEndDocument();
        }
    }

    private static void WriteAlbum(XmlTextWriter writer, string name, string artist)
    {
        writer.WriteStartElement("album");
        writer.WriteElementString("name", name);
        writer.WriteElementString("artist", artist);
        writer.WriteEndElement();
    }
}
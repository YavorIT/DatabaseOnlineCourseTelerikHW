
/*
    Using the DOM parser write a program to delete from catalog.xml all albums having price > 20.
*/

using System.Xml;

class DOMDelete
{
    static void Main()
    {
        XmlDocument doc = new XmlDocument();
        doc.Load(@"..\..\..\catalogue.xml");
        XmlNode rootNode = doc.DocumentElement;

        for (int i = 0; i < rootNode.ChildNodes.Count; i++)
        {
            XmlNode node = rootNode.ChildNodes[i];

            foreach (XmlNode albumPrice in node.ChildNodes)
            {
                // if the node is the price node
                if (albumPrice.Name == "price")
                {
                    // take the price 
                    double price = double.Parse(albumPrice.InnerText);
                    if (price > 20.00)
                    {
                        rootNode.RemoveChild(node); // remove the node
                        i--; // decrementing i so that we won't miss a node
                    }
                }
            }
        }

        doc.Save(@"..\..\..\catalogueUnderTwentyPrice.xml");
    }
}
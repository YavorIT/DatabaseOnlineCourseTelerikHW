/*
             Using JSON.NET and the Telerik Academy Youtube RSS feed, implement the following:

    The RSS feed is located at https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw
    1. Download the content of the feed programatically
    2. You can use WebClient.DownloadFile()
    3. Parse the XML from the feed to JSON
    4. Using LINQ-to-JSON select all the video titles and print them on the console
    5. Parse the videos' JSON to POCO
    6. Using the POCOs create a HTML page that shows all videos from the RSS
       -Use <iframe>
    7. Provide links, that nagivate to their videos in YouTube
*/

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Text;
using System.Xml;

namespace JSONDotNet
{
    class MainClass
    {
        static void Main()
        {
            // RSS Feed link
            string dataLink = "https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw";

            // Download the RSS
            var webClient = new WebClient();
            var data = webClient.DownloadData(dataLink);

            // Create the xml and load it
            XmlDocument doc = new XmlDocument();
            var xml = Encoding.UTF8.GetString(data);
            doc.LoadXml(xml);

            // Transform the xml to JSON object to use Linq
            var json = JsonConvert.SerializeXmlNode(doc, Newtonsoft.Json.Formatting.Indented);
            var jsonLinq = JObject.Parse(json);

            // Get the videos' titles
            var titles = Tasks.GetVideoTitles(jsonLinq);

            // Print the video titles
            Tasks.PrintTitles(titles);

            // Get the videos ID, Name and link
            var videos = Tasks.GetVideos(jsonLinq);

            // Make the HTML string
            var htmlDoc = Tasks.GetHTML(videos);

            // Save the HTML string to a html file
            Tasks.SaveHTMLToFile(htmlDoc);
        }
    }
}

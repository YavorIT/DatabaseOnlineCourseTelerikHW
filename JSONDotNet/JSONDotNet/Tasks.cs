using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JSONDotNet
{
    class Tasks
    {
        public static IEnumerable<JToken> GetVideoTitles(JObject obj)
        {
            return obj["feed"]["entry"].
                        Select(x => x["title"]);
        }

        public static void PrintTitles(IEnumerable<JToken> titles)
        {
            Console.WriteLine("\n\tVideo titles: ");
            int count = 1;
            foreach (var title in titles)
            {
                Console.WriteLine("{0}. {1}", count, title);
                count++;
            }
        }

        public static IEnumerable<AcademyVideos> GetVideos(JObject obj)
        {
            return obj["feed"]["entry"].
                                    Select(video => JsonConvert.DeserializeObject<AcademyVideos>(video.ToString()));
        }

        public static void SaveHTMLToFile(String htmlText)
        {
            Encoding encoding = Encoding.GetEncoding("utf-8");
            StreamWriter writer = new StreamWriter(@"..\..\..\TelerikAcademyVideos.html", false, encoding);
            using (writer)
            {
                writer.WriteLine(htmlText);
            }
        }

        public static string GetHTML(IEnumerable<AcademyVideos> videos)
        {
            StringBuilder htmlCode = new StringBuilder();

            htmlCode.Append("<html>\n<body>");
            foreach (var video in videos)
            {
                htmlCode.AppendFormat("<iframe width=\"500\" height=\"400\" src=\"http://www.youtube.com/embed/{0}?autoplay=0\" frameborder=\"1\"></iframe><h1 a href=\"{2}\">{1}<h1>>", video.ID, video.Title, video.Link);
            }
            htmlCode.Append("</body></html>");
            return htmlCode.ToString();
        }
    }
}

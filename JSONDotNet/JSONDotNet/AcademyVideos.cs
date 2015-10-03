using Newtonsoft.Json;
using System;

namespace JSONDotNet
{
    class AcademyVideos
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public Link Link { get; set; }

        [JsonProperty("yt:videoId")]
        public string ID { get; set; }
    }
}

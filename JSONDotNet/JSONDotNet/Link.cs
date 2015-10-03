using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONDotNet
{
    class Link
    {
        [JsonProperty("@rel")]
        public string rel { get; set; }

        [JsonProperty("@href")]
        public string href { get; set; }
    }
}

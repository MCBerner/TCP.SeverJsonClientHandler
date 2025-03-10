using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCP.ServerJsonClientHandler
{
    using System.Text.Json.Serialization;

    namespace TCP.ServerJsonClientHandler
    {
        public class Request
        {
            [JsonPropertyName("method")]
            public string Method { get; set; }

            [JsonPropertyName("Tal1")]
            public int Tal1 { get; set; }

            [JsonPropertyName("Tal2")]
            public int Tal2 { get; set; }
        }
    }

}

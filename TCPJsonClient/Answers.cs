using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json.Serialization;

namespace TCP.ServerJsonClientHandler
{
    public class Answers
    {
        [JsonPropertyName("method")]
        public string Method { get; set; }

        [JsonPropertyName("num1")]
        public int Num1 { get; set; }

        [JsonPropertyName("num2")]
        public int Num2 { get; set; }

        [JsonPropertyName("result")]
        public int Result { get; set; }
    }
}


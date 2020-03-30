using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Cw3.Models
{
    [Serializable]
    public class Study
    {
        [JsonPropertyName("IdStudy")]
        public int IdStudy { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
    }
}

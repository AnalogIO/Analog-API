using Newtonsoft.Json;

namespace Analog_API.Models
{
    public class Business
    {
        [JsonProperty("language")]
        public string Language { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("fax")]
        public string Fax { get; set; }
    }
}

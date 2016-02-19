using Newtonsoft.Json;

namespace Analog_API.Models
{
    public class Data
    {
        [JsonProperty("employee")]
        public Employee Employee { get; set; }

        [JsonProperty("business")]
        public Business Business { get; set; }
    }
}

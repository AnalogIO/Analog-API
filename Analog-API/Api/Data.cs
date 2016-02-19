using Newtonsoft.Json;

namespace Analog_API.Api
{
    public class Data
    {
        [JsonProperty("employee")]
        public Employee Employee { get; set; }

        [JsonProperty("business")]
        public Business Business { get; set; }
    }
}
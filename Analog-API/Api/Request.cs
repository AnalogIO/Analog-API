using Newtonsoft.Json;

namespace Analog_API.Api
{
    public abstract class Request
    {
        [JsonProperty("module")]
        public string Module { get; set; }

        [JsonProperty("method")]
        public string Method { get; set; }
    }
}
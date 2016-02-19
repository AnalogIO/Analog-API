using Newtonsoft.Json;

namespace Analog_API.Api
{
    public class LoginData
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("data")]
        public Data Data { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}
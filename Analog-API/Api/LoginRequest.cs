using Newtonsoft.Json;

namespace Analog_API.Api
{
    public class LoginRequest : Request
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
using Newtonsoft.Json;

namespace Analog_API.Models
{
    public class LoginRequest : Request
    {
        public LoginRequest()
        {
            Module = "staff.login";
        }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}

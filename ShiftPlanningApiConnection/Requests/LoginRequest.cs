using Newtonsoft.Json;

namespace ShiftPlanningApiConnection.Requests
{
    public class LoginRequest : Request
    {
        public LoginRequest() : base("staff.login"){ }

        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}

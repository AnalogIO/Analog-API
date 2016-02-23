using Newtonsoft.Json;
using ShiftPlanningApiConnection.Requests;

namespace ShiftPlanningApiConnection.Models
{
    public class ShiftPlanningApiRequest
    {
        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("output")]
        public string Output { get; set; }

        [JsonProperty("request")]
        public Request Request { get; set; }

    }
}

using Newtonsoft.Json;

namespace ShiftPlanningApiConnection.Models
{
    public class Data
    {
        [JsonProperty("employee")]
        public Employee Employee { get; set; }

        [JsonProperty("business")]
        public Business Business { get; set; }
    }
}

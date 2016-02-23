using Newtonsoft.Json;

namespace ShiftPlanningApiConnection.Models
{
    public class Avatar
    {
        [JsonProperty("small")]
        public string Small { get; set; }

        [JsonProperty("medium")]
        public string Medium { get; set; }

        [JsonProperty("large")]
        public string Large { get; set; }
    }
}

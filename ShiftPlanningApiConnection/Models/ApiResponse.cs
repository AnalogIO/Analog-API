using Newtonsoft.Json;

namespace ShiftPlanningApiConnection.Models
{
    public class ApiResponse<TData>
    {
        [JsonProperty("status")]
        public int Status { get; set; }

        [JsonProperty("data")]
        public TData Data { get; set; }

        [JsonProperty("token")]
        public string Token { get; set; }
    }
}

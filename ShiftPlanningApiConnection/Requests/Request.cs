using Newtonsoft.Json;

namespace ShiftPlanningApiConnection.Requests
{
    public abstract class Request
    {
        protected Request(string module)
        {
            Module = module;
        }

        [JsonProperty("module")]
        protected string Module { get; }

        [JsonProperty("method")]
        public string Method { get; set; }
    }
}

using Newtonsoft.Json;

namespace StepsTracker.Models
{
    public class UserDaylyInfo
    {
        [JsonProperty("Rank")]
        public int Rank { get; set; }

        [JsonProperty("User")]
        public string UserName { get; set; }

        [JsonProperty("Status")]
        public string Status { get; set; }

        [JsonProperty("Steps")]
        public int Steps { get; set; }
    }
}

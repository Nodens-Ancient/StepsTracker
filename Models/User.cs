using Newtonsoft.Json;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace StepsTracker.Models
{
    [DataContract]
    public class User
    {
        [JsonProperty("UserName")]
        [DataMember]
        public string UserName { get; set; }

        [JsonProperty("UserStats")]
        [DataMember]
        public Dictionary<int, UserDaylyInfo> UserStats;
    }
}

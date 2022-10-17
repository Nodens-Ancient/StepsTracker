using Newtonsoft.Json;
using StepsTracker.Models;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;


namespace StepsTracker.ViewModel
{
    public class UserView
    {
        public User User { get; }

        public UserView(User user)
        {
            User = user;
        }

        public UserView()
        {
        }

        [JsonProperty("UserName")]
        public string UserName
        {
            get => User.UserName;
            set { }
        }
        

        [JsonProperty("BestResult")]
        public int BestResult
        {
            get => User.UserStats.Values.ToList().Max(stat => stat.Steps);
            set { }
        }

        [JsonProperty("WorstResult")]
        public int WorstResult
        {
            get => User.UserStats.Values.ToList().Min(stat => stat.Steps);
            set { }
        }

        [XmlIgnore]
        public int AverageSteps => (int)User.UserStats.Values.ToList().Average(stat => stat.Steps);
        [XmlIgnore]
        public int BestDay => User.UserStats.Aggregate((p1,p2) => p1.Value.Steps > p2.Value.Steps ? p1 : p2).Key;
        [XmlIgnore]
        public int WorstDay => User.UserStats.Aggregate((p1, p2) => p1.Value.Steps < p2.Value.Steps ? p1 : p2).Key;
        [XmlIgnore]
        public Dictionary<int, UserDaylyInfo> UserStats => User.UserStats;

        [JsonProperty("UserStatus")]
        public string UserStatus
        {
            get => User.UserStats.Values.Last().Status;
            set { }
        }

        [JsonProperty("UserRank")]
        public int UserRank
        {
            get => User.UserStats.Values.Last().Rank;
            set { }
        }
    }
}

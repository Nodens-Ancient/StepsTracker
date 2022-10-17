using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepsTracker.Models
{
    internal class AllDayInfo
    {
        [JsonProperty("")]
        public List<UserDaylyInfo> userDaylyInfo { get; set; }
    }
}

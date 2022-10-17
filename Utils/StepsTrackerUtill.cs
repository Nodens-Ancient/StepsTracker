using Newtonsoft.Json;
using StepsTracker.Models;
using StepsTracker.ViewModel;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StepsTracker.Utils
{
    internal class StepsTrackerUtill
    {
        public static List<User> ParseDays()
        {
            var users = new List<User>();

            for (int i  = 1; i <= 30; i++)
            {
                var dayInfo = File.ReadAllText($@"Resources\day{i}.json");
                var inf = JsonConvert.DeserializeObject<List<UserDaylyInfo>>(dayInfo);

                inf.ForEach(dInfo =>
                {
                    var interestUser = users.FirstOrDefault(usr => dInfo.UserName.Equals(usr.UserName));
                    if (interestUser != null)
                        interestUser.UserStats.Add(i, dInfo);
                    else
                    {
                        users.Add(new User()
                        {
                            UserName = dInfo.UserName,
                            UserStats = new Dictionary<int, UserDaylyInfo>() { { i, dInfo} }
                        });
                    }
                });
            }

            return users;
        } 

        public static List<UserView> SetUserListView(List<User> users)
        {
            List<UserView> userViews = new List<UserView>();
            users.ForEach(usr => userViews.Add(new UserView(usr)));
            return userViews;
        }

        public static List<UserView> SetUpUserContext()
        {
            var userModels = ParseDays();
            return SetUserListView(userModels);
        }
    }
}

using StepsTracker.Utils;
using StepsTracker.ViewModel;
using System.Collections.Generic;

namespace StepsTracker.View
{
    internal class ApplicationContext
    {
        public List<UserView> Users { get; set; }
        
        public string ASD { get; set; }

        public ApplicationContext()
        {
            Users = StepsTrackerUtill.SetUpUserContext();
        }
    }
}

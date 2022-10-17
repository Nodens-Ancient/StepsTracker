using StepsTracker.Models;
using StepsTracker.ViewModel;
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace StepsTracker.Utils
{
    internal class AverageStepsToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var user = (UserView)value;
            if (user.WorstResult * 1.2 < user.AverageSteps || user.BestResult >= user.AverageSteps * 1.2)
                return new SolidColorBrush(Colors.Red);
            else return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

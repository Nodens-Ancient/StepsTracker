using Microsoft.Win32;
using StepsTracker.Utils;
using StepsTracker.View;
using StepsTracker.ViewModel;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace StepsTracker
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new ApplicationContext();

            InitWpfPlot();
        }
        
        private void InitWpfPlot()
        {
            var plot = WpfPlot1.Plot;
            plot.XLabel("Days");
            plot.YLabel("Steps");
            plot.XAxis.ManualTickSpacing(1);
        }

        private void userList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            WpfPlot1.Plot.Clear();
            DataGrid dataGrid = (DataGrid)sender;
            var user = dataGrid.SelectedItem as UserView;
            WpfPlot1.Plot.AddScatter(user.UserStats.Keys.Select(key => Convert.ToDouble(key)).ToArray(), user.UserStats.Values.Select(value => Convert.ToDouble(value.Steps)).ToArray());
            var plt = WpfPlot1.Plot;
            plt.AddMarker(user.BestDay, Convert.ToDouble(user.UserStats[user.BestDay].Steps));
            plt.AddMarker(user.WorstDay, Convert.ToDouble(user.UserStats[user.WorstDay].Steps));
            WpfPlot1.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialogWindow = new SaveFileDialog();
            dialogWindow.Filter = "JSON file(*.json)|*.json | xml file (*.xml)|*.xml | csv file(*.csv)|*.csv";

            if (dialogWindow.ShowDialog() == true)
            {
                FileSaver.SaveObjectToFile((userList.SelectedItem as UserView), dialogWindow.FilterIndex, dialogWindow.FileName);
                var user = userList.SelectedItem as UserView;
                var filind = dialogWindow.FilterIndex;
            }
        }
    }
}

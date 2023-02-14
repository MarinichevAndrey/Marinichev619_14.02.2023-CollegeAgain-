using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Marinichev619_14._02._2023
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService.CanGoBack)
                MainFrame.NavigationService.GoBack();
        }

        private void btnForward_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.NavigationService.CanGoForward)
                MainFrame.NavigationService.GoForward();
        }

        private void btnStudents_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.StudentsPage());
        }

        private void btnGroups_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new Pages.GroupsPage());
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            var newwind = new SettingsWindow();
            newwind.Show();
        }
    }
}

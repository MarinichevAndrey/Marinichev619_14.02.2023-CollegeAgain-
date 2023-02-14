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

namespace Marinichev619_14._02._2023.Pages
{
    /// <summary>
    /// Логика взаимодействия для GroupsPage.xaml
    /// </summary>
    public partial class GroupsPage : Page
    {
        public GroupsPage()
        {
            InitializeComponent();
            var groupsinfo = Entities.GetContext().Groups.ToList();
            var studentsinfo = Entities.GetContext().Students.ToList();
            GroupsList.ItemsSource = groupsinfo;
            StudentsList.ItemsSource = studentsinfo;
        }

        private void GroupsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var studentsinfo = Entities.GetContext().Students.ToList();
            var item = GroupsList.SelectedItem as Groups;
            studentsinfo = item.Students.ToList();
            StudentsList.ItemsSource = studentsinfo;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            var item = StudentsList.SelectedItem as Students;
            NavigationService.Navigate(new AddEditStudentPage(item));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var item = StudentsList.SelectedItem as Students;
            try
            {
                Entities.GetContext().Students.Remove(item);
                Entities.GetContext().SaveChanges();
                MessageBox.Show("Студент успешно удалён", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                var studentsinfo = Entities.GetContext().Students.ToList();
                StudentsList.ItemsSource = studentsinfo;
            }
            catch
            {
                MessageBox.Show("Ошибка при удалении студента", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            var groupsinfo = Entities.GetContext().Groups.ToList();
            var studentsinfo = Entities.GetContext().Students.ToList();
            GroupsList.ItemsSource = groupsinfo;
            StudentsList.ItemsSource = studentsinfo;
        }
    }
}

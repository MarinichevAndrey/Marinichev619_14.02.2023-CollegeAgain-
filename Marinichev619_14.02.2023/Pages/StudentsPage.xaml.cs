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
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        public StudentsPage()
        {
            InitializeComponent();
            var studentsinfo = Entities.GetContext().Students.ToList();
            var groupsinfo = Entities.GetContext().Groups.ToList();
            cmbGroup.ItemsSource = groupsinfo;
            StudentsList.ItemsSource = studentsinfo;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEditStudentPage(null));
        }

        private void tbSearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateDate();
        }

        private void cmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            UpdateDate();
        }

        private void UpdateDate()
        {
            var searchtxt = tbSearchBox.Text;
            var stinfo = Entities.GetContext().Students.ToList();
            var selgrp = cmbGroup.SelectedItem as Groups;
            stinfo = stinfo.Where(s => s.Surname.ToLower().Contains(searchtxt.ToLower()) ||
            s.Name.ToLower().Contains(searchtxt.ToLower()) ||
            s.Patronymic.ToLower().Contains(searchtxt.ToLower())).ToList();
            if (cmbGroup.SelectedItem != null)
            {
                stinfo = stinfo.Where(p => p.GroupID == cmbGroup.SelectedIndex+1).ToList();
            }
            StudentsList.ItemsSource = stinfo;
        }
    }
}

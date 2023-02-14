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
    /// Логика взаимодействия для AddEditStudentPage.xaml
    /// </summary>
    public partial class AddEditStudentPage : Page
    {
        bool check = false;
        Students St;
        public AddEditStudentPage(Students s)
        {
            InitializeComponent();
            var studentsinfo = Entities.GetContext().Students.ToList();
            var groupsinfo = Entities.GetContext().Groups.ToList();
            cmbGroup.ItemsSource = groupsinfo;
            if (s != null)
            {
                check = true;
                tbSurname.Text = s.Surname;
                tbName.Text = s.Name;
                tbPatronymic.Text = s.Patronymic;
                cmbGroup.SelectedIndex = Convert.ToInt32(s.GroupID)-1;
            }    
            St = s;
        }


        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            if (check == false)
            {
                var newst = new Students();
                try
                {
                    var newstid = Entities.GetContext().Students.ToList().Last();
                    newst.IdStudent = newstid.IdStudent + 1;
                    newst.Surname = tbSurname.Text;
                    newst.Name = tbName.Text;
                    newst.Patronymic = tbPatronymic.Text;
                    newst.GroupID = cmbGroup.SelectedIndex+1;
                    Entities.GetContext().Students.Add(newst);
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Пользователь успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка при добавлении пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            else
            {
                try
                {
                    St.Surname = tbSurname.Text;
                    St.Name = tbName.Text;
                    St.Patronymic = tbPatronymic.Text;
                    St.GroupID = cmbGroup.SelectedIndex+1;
                    Entities.GetContext().SaveChanges();
                    MessageBox.Show("Пользователь успешно изменён", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch
                {
                    MessageBox.Show("Ошибка при внесении данных пользователя", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

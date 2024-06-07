using DrivingSchool.Classes;
using DrivingSchool.DataBase;
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
using System.Windows.Shapes;

namespace DrivingSchool.Windows
{
    /// <summary>
    /// Логика взаимодействия для StutentListWindow.xaml
    /// </summary>
    public partial class StutentListWindow : Window
    {
        public StutentListWindow()
        {
            InitializeComponent();

            lvStudent.ItemsSource = DBClass.context.Student.ToList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            StudentsWindow studentsWindow = new StudentsWindow();
            studentsWindow.Show();
            this.Close();
        }
        private void UpdateList()
        {
            if (tbxFilter.Text != "Введите данные ученика" && tbxFilter.Text != "")
            {
                lvStudent.ItemsSource = DBClass.context.Student.Where(p => p.LastName.ToString().Contains(tbxFilter.Text.ToString())).ToList();
            }
            else if (tbxFilter.Text == "")
            {
                lvStudent.ItemsSource = DBClass.context.Student.ToList();
            }
            else
            {
                return;
            }
        }

        private void tbxFilter_GotMouseCapture(object sender, MouseEventArgs e)
        {
            tbxFilter.Text = "";
        }

        private void tbxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateList();
        }
    }
}

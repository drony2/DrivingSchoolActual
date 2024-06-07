using DrivingSchool.Classes;
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
    /// Логика взаимодействия для InstructorListWindow.xaml
    /// </summary>
    public partial class InstructorListWindow : Window
    {
        public InstructorListWindow()
        {
            InitializeComponent();

            lvInstructor.ItemsSource = DBClass.context.Instructor.ToList();
            UpdateList();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            InstructorsWindow instructorsWindow = new InstructorsWindow();
            instructorsWindow.Show();
            this.Close();
        }

        private void UpdateList()
        {
            if (tbxFilter.Text != "Введите данные инструктора" && tbxFilter.Text != "")
            {
                lvInstructor.ItemsSource = DBClass.context.Instructor.Where(p => p.LastName.ToString().Contains(tbxFilter.Text.ToString())).ToList();
            }
            else if (tbxFilter.Text == "")
            {
                lvInstructor.ItemsSource = DBClass.context.Instructor.ToList();
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

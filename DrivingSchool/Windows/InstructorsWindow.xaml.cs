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

using DrivingSchool.Windows;

namespace DrivingSchool.Windows
{
    /// <summary>
    /// Логика взаимодействия для InstructorsWindow.xaml
    /// </summary>
    public partial class InstructorsWindow : Window
    {
        public InstructorsWindow()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void btnInstructorList_Click(object sender, RoutedEventArgs e)
        {
            InstructorListWindow instructorListWindow = new InstructorListWindow();
            instructorListWindow.Show();
            this.Close();
        }

        private void btnAddInstructor_Click(object sender, RoutedEventArgs e)
        {
            AddInstructorWindow addInstructorWindow = new AddInstructorWindow();
            addInstructorWindow.Show();
            this.Close();
        }

    }
}

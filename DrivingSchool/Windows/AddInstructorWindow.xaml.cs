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
    /// Логика взаимодействия для AddInstructorWindow.xaml
    /// </summary>
    public partial class AddInstructorWindow : Window
    {
        public AddInstructorWindow()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            InstructorsWindow instructorsWindow = new InstructorsWindow();
            instructorsWindow.Show();
            this.Close();
        }

        private void btnAddInstructor_Click(object sender, RoutedEventArgs e)
        {
            // Добавление паспорта 
            DataBase.Pasport pasport = new DataBase.Pasport();
            pasport.DateOfIssue = dpDateOfIssue.SelectedDate.Value;
            pasport.PlaceOfIssue = txtPlaceOfIssue.Text;
            pasport.PassportSeries = txtSeriesPasport.Text;
            pasport.PassportNumber = txtNumberPasport.Text;
            Classes.DBClass.context.Pasport.Add(pasport);

            Classes.DBClass.context.SaveChanges();

            // Добавление ученика 

            DataBase.Instructor instructor = new DataBase.Instructor();
            instructor.LastName = txtLastName.Text;
            instructor.FirstName = txtFirstName.Text;
            instructor.Patronymic = txtPatronymic.Text;
            instructor.DateOfBirth = dpDateOfBirth.SelectedDate.Value;
            instructor.IDPasport = Classes.DBClass.context.Pasport.ToList().LastOrDefault().ID;
            Classes.DBClass.context.Instructor.Add(instructor);

            Classes.DBClass.context.SaveChanges();

            MessageBox.Show("Инструктор добавлен в систему", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            InstructorsWindow instructorsWindow = new InstructorsWindow();
            instructorsWindow.Show();
            this.Close();
        }
    }
}

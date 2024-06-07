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
    /// Логика взаимодействия для AddStudentWindow.xaml
    /// </summary>
    public partial class AddStudentWindow : Window
    {
        public AddStudentWindow()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            StudentsWindow studentsWindow = new StudentsWindow();
            studentsWindow.Show();
            this.Close();
        }

        private void btnAddStudent_Click(object sender, RoutedEventArgs e)
        {
            // валидация

            if (!Int32.TryParse(txtSeriesPasport.Text, out int res))
            {
                MessageBox.Show("Неверный формат данных Серия паспорта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!Int32.TryParse(txtNumberPasport.Text, out int ress))
            {
                MessageBox.Show("Неверный формат данных Номер паспорта", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            if (txtLastName.Text == "Введите фамилию" 
                || txtFirstName.Text == "Введите имя"
                || txtSeriesPasport.Text == "Введите серию паспорта"
                || txtNumberPasport.Text == "Введите номер паспорта"
                || txtPlaceOfIssue.Text == "Введите место выдачи")
            {
                MessageBox.Show("Заполните все поля", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            try
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

                DataBase.Student student = new DataBase.Student();
                student.LastName = txtLastName.Text;
                student.FirstName = txtFirstName.Text;
                student.Patronymic = txtPatronymic.Text;
                student.DateOfBirth = dpDateOfBirth.SelectedDate.Value;
                student.IDPasport = Classes.DBClass.context.Pasport.ToList().LastOrDefault().ID;
                Classes.DBClass.context.Student.Add(student);

                Classes.DBClass.context.SaveChanges();

                MessageBox.Show("Ученик добавлен в систему", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                StudentsWindow studentsWindow = new StudentsWindow();
                studentsWindow.Show();
                this.Close();
            }
            catch (Exception)
            {
               MessageBox.Show("Ошибка добавления данных в систему! Проверьте введенные данные!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
               return;
            }
            


        }

        // очистка полей
        //Фамилия
        private void txtLastName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtLastName.Text == "Введите фамилию")
            {
                txtLastName.Text = "";
            }
        }

        private void txtLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtLastName.Text == "")
            {
                txtLastName.Text = "Введите фамилию";
            }
        }

        // Имя
        private void txtFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtFirstName.Text == "Введите имя")
            {
                txtFirstName.Text = "";
            }
        }

        private void txtFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtFirstName.Text == "")
            {
                txtFirstName.Text = "Введите имя";
            }
        }
        // Отчество
        private void txtPatronymic_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPatronymic.Text == "Введите отчество")
            {
                txtPatronymic.Text = "";
            }
        }

        private void txtPatronymic_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPatronymic.Text == "")
            {
                txtPatronymic.Text = "Введите отчество";
            }
        }

        // Серия паспорта
        private void txtSeriesPasport_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtSeriesPasport.Text == "Введите серию паспорта")
            {
                txtSeriesPasport.Text = "";
            }
        }

        private void txtSeriesPasport_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtSeriesPasport.Text == "")
            {
                txtSeriesPasport.Text = "Введите серию паспорта";
            }
        }
        // Номер паспорта
        private void txtNumberPasport_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtNumberPasport.Text == "Введите номер паспорта")
            {
                txtNumberPasport.Text = "";
            }
        }

        private void txtNumberPasport_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtNumberPasport.Text == "")
            {
                txtNumberPasport.Text = "Введите номер паспорта";
            }
        }

        // Место выдачи
        private void txtPlaceOfIssue_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPlaceOfIssue.Text == "Введите место выдачи")
            {
                txtPlaceOfIssue.Text = "";
            }
        }

        private void txtPlaceOfIssue_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPlaceOfIssue.Text == "")
            {
                txtPlaceOfIssue.Text = "Введите место выдачи";
            }
        }

       
    }
}

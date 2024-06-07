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
    /// Логика взаимодействия для AddOrderWindow.xaml
    /// </summary>
    public partial class AddOrderWindow : Window
    {
        public AddOrderWindow()
        {
            InitializeComponent();

            cmbStudent.ItemsSource = Classes.DBClass.context.Student.ToList();
            cmbStudent.DisplayMemberPath = "StudentName";
            cmbStudent.SelectedIndex = 0;

            cmbInstructor.ItemsSource = Classes.DBClass.context.Instructor.ToList();
            cmbInstructor.DisplayMemberPath = "InstructorName";
            cmbInstructor.SelectedIndex = 0;

            cmbCategory.ItemsSource = Classes.DBClass.context.Category.ToList();
            cmbCategory.DisplayMemberPath = "NameCategory";
            cmbCategory.SelectedIndex = 0;

        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            CategoryAWindow categoryAWindow = new CategoryAWindow();
            categoryAWindow.Show();
            this.Close();
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.IDStudent = (cmbStudent.SelectedItem as Student).ID;
            order.IDInstructor = (cmbInstructor.SelectedItem as Instructor).ID;
            order.IDCategory = (cmbCategory.SelectedItem as Category).ID;
            order.DateOrder = dpDateOrder.SelectedDate.Value;

            Classes.DBClass.context.Order.Add(order);
            Classes.DBClass.context.SaveChanges();

            MessageBox.Show($"Ученик {(cmbStudent.SelectedItem as Student).StudentName} успешно записан на курс {(cmbCategory.SelectedItem as Category).NameCategory} к {(cmbInstructor.SelectedItem as Instructor).InstructorName}!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }
    }
}

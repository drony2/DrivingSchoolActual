using DrivingSchool.Classes;
using System.Data.Entity.Core.Mapping;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;



namespace DrivingSchool.Windows
{
    /// <summary>
    /// Логика взаимодействия для ReportsWindow.xaml
    /// </summary>
    public partial class ReportsWindow : Window
    {
        public ReportsWindow()
        {
            InitializeComponent();

            lvReport.ItemsSource = DBClass.context.Order.ToList();

            cbxCategory.ItemsSource = DBClass.context.Category.ToList();
            cbxCategory.DisplayMemberPath = "NameCategory";


        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void tbxPoisk_GotMouseCapture(object sender, MouseEventArgs e)
        {
            if (tbxPoisk.Text == "Введите данные")
            {
                tbxPoisk.Text = "";
            }
        }

        private void UpdateList()
        {
            if (tbxPoisk.Text == "" && cbxCategory.Text == "")
            {
                lvReport.ItemsSource = DBClass.context.Order.ToList();
            }
            else if (tbxPoisk.Text != "" && cbxCategory.Text.ToString() == "" && tbxPoisk.Text != "Введите данные")
            {
                lvReport.ItemsSource = DBClass.context.Order.Where(p => p.Student.LastName.Contains(tbxPoisk.Text.ToString())).ToList();
            }
            else if (tbxPoisk.Text == "" || tbxPoisk.Text == "Введите данные" && cbxCategory.Text.ToString() != "")
            {
                lvReport.ItemsSource = DBClass.context.Order.Where(p => p.Category.NameCategory == cbxCategory.Text.ToString()).ToList();
            }
            else if (tbxPoisk.Text != "" && cbxCategory.Text.ToString() != "" && tbxPoisk.Text != "Введите данные")
            {
                lvReport.ItemsSource = DBClass.context.Order.Where(p => p.Category.NameCategory == cbxCategory.Text.ToString() &&
                p.Student.LastName.Contains(tbxPoisk.Text.ToString())).ToList();
            }
            
        }

        private void tbxPoisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (tbxPoisk.Text != "Введите данные")
            {
                UpdateList();
            }
        }

        private void btnPoisk_Click(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void btnRes_Click(object sender, RoutedEventArgs e)
        {
            lvReport.ItemsSource = DBClass.context.Order.ToList();
            tbxPoisk.Text = "";
            cbxCategory.Text = "";
        }
    }
}

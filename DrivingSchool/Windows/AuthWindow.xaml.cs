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
using DrivingSchool.Classes;

namespace DrivingSchool.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var userAuth = DBClass.context.Instructor.ToList()
                .Where(i => i.Login == txtLogin.Text && i.Password == txtPassword.Text).FirstOrDefault();
            if (userAuth != null)
            {
                MenuWindow menuWindow = new MenuWindow();
                menuWindow.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           
        }

        private void txtLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == "Введите логин")
            {
                txtLogin.Text = "";
            }
        }

        private void txtLogin_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtLogin.Text == "")
            {
                txtLogin.Text = "Введите логин";
            }
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Text == "Введите пароль")
            {
                txtPassword.Text = "";
            }
        }

        private void txtPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtPassword.Text == "")
            {
                txtPassword.Text = "Введите пароль";
            }
        }
    }
}

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
    /// Логика взаимодействия для CategoryBWindow.xaml
    /// </summary>
    public partial class CategoryBWindow : Window
    {
        public CategoryBWindow()
        {
            InitializeComponent();
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            AddOrderWindow addOrderWindow = new AddOrderWindow();
            addOrderWindow.Show();
            this.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            CourseWindow courseWindow = new CourseWindow();
            courseWindow.Show();
            this.Close();
        }
    }
}

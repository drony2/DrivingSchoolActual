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
    /// Логика взаимодействия для CourseWindow.xaml
    /// </summary>
    public partial class CourseWindow : Window
    {
        public CourseWindow()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            MenuWindow menuWindow = new MenuWindow();
            menuWindow.Show();
            this.Close();
        }

        private void btnCategoryD_Click(object sender, RoutedEventArgs e)
        {
            CategoryDWindow categoryDWindow = new CategoryDWindow();
            categoryDWindow.Show();
            this.Close();
        }

        private void btnCategoryC_Click(object sender, RoutedEventArgs e)
        {
            CategoryCWindow categoryCWindow = new CategoryCWindow();
            categoryCWindow.Show();
            this.Close();
        }
    

        private void btnCategoryB_Click(object sender, RoutedEventArgs e)
        {
            CategoryBWindow categoryBWindow = new CategoryBWindow();
            categoryBWindow.Show();
            this.Close();
        }

        private void btnCategoryA_Click(object sender, RoutedEventArgs e)
        {
            CategoryAWindow categoryAWindow = new CategoryAWindow();
            categoryAWindow.Show();
            this.Close();
        }




    }
}

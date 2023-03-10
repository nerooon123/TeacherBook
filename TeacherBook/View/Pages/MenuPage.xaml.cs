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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TeacherBook.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }

        private void ListStudent_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new GroupPage());
        }

        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddStudentPage());
        }

        private void AddEstimation_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AddEstimationPage());
        }

        private void DellStudent_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new DellStudentPage());
        }

        private void ConstructEstimation_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ConstructEstimationPage());
        }
    }
}

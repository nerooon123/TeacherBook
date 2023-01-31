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
using TeacherBook.Classes;
using TeacherBook.Controllers;
using TeacherBook.Model;

namespace TeacherBook.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для SigInPage.xaml
    /// </summary>
    public partial class SigInPage : Page
    {
        Core db = new Core();
        List<Users> arrayClients;
        UserController obj = new UserController();
        CorrectStringClass classObj = new CorrectStringClass();
        public SigInPage()
        {
            InitializeComponent();
            arrayClients = db.context.Users.ToList();
        }

        private void SingInButton_Click(object sender, RoutedEventArgs e)
        {
            if (classObj.StringOfEmpty(LogInTextBox.Text) && classObj.StringOfEmpty(AuthPasswordBox.Password))
            {
               

                if (obj.Auth(LogInTextBox.Text, AuthPasswordBox.Password))
                {
                    this.NavigationService.Navigate(new MenuPage());
                }
                else
                {
                    MessageBox.Show("Введены неправильные данные");
                }
            }
            else
            {
                MessageBox.Show("Не введен логин или пароль!");
            }
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RegPage());
        }
    }
}

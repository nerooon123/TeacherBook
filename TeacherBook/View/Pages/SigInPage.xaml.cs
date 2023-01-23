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
        public SigInPage()
        {
            InitializeComponent();
            arrayClients = db.context.Users.ToList();
        }

        private void SingInButton_Click(object sender, RoutedEventArgs e)
        {
            if (LogInTextBox.Text != String.Empty
                && AuthPasswordBox.Password != String.Empty
                && !String.IsNullOrWhiteSpace(LogInTextBox.Text)
                && !String.IsNullOrWhiteSpace(AuthPasswordBox.Password))
            {
                Users activeUser = arrayClients
                .Where(x => x.Login == LogInTextBox.Text && x.Password == AuthPasswordBox.Password).FirstOrDefault();
                if (activeUser != null)
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

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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        Core db = new Core();
        public RegPage()
        {
            InitializeComponent();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text.Length > 0) // проверяем введён ли логин     
            {
                if (Password.Text.Length > 0) // проверяем введён ли пароль         
                {
                    if (db.context.Users.Count(x => x.Login == LoginTextBox.Text) > 0)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует!", "Увидомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                    }
                    try
                    {
                        Users userObj = new Users()
                        {
                            Login = LoginTextBox.Text,
                            Password = Password.Text,
                            IdRole = 1
                            // ...
                        };
                        db.context.Users.Add(userObj);
                        db.context.SaveChanges();
                        MessageBox.Show("Данные успешно добавлениы!", "Увидомление", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.NavigationService.Navigate(new SigInPage());
                    }
                    catch
                    {
                        MessageBox.Show("Ошибка при добавление данных!", "Увидомление", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else MessageBox.Show("Введите пароль"); // выводим ошибку    
            }
            else MessageBox.Show("Введите логин"); // выводим ошибку
        }
    }
}

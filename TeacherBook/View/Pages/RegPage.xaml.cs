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
            // reg
        }

        private void Role_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Role.ItemsSource = db.context.Role.ToList();

            Role.DisplayMemberPath = "NameRole";
        }
    }
}

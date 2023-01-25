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
    /// Логика взаимодействия для ConstructEstimationPage.xaml
    /// </summary>
    public partial class ConstructEstimationPage : Page
    {
        Core db = new Core();
        public ConstructEstimationPage()
        {
            InitializeComponent();
            GroupNameComboBox.ItemsSource = db.context.Groups.ToList();
            GroupNameComboBox.DisplayMemberPath = "NameGroup";
            GroupDataGrid.ItemsSource = db.context.Students.ToList();
            GroupDataGrid.ItemsSource = db.context.Groups.ToList();
            GroupDataGrid.ItemsSource = db.context.Subjects.ToList();

        }

        private void GroupNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int obj = 1 + Convert.ToInt32(GroupNameComboBox.SelectedIndex);

            GroupDataGrid.ItemsSource = db.context.Journals.Where(x => x.IdGroup == obj).ToList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var item = GroupDataGrid.SelectedItem as Journals;

                //проверка того, что пользователь выбрал строки для удаления

                if (item == null)

                {
                    MessageBox.Show("Вы не выбрали ни одной строки");
                }
                else
                {
                    db.context.SaveChanges();
                    MessageBox.Show("Данные успешно добавлениы!", "Увидомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.NavigationService.Navigate(new MenuPage());
                }
            }
            catch (Exception)

            {
                MessageBox.Show("Данные не отредактированы. ");
            }
        }
    }
}

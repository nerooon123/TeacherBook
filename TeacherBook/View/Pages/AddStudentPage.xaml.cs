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
    /// Логика взаимодействия для AddStudentPage.xaml
    /// </summary>
    public partial class AddStudentPage : Page
    {
        Core db = new Core();
        public AddStudentPage()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Students studObj = new Students()
                {
                    FiestName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text,
                    PatronomicName = PatronomicTextBox.Text,
                    IdProfession = ProfessionComboBox.SelectedIndex,
                    IdFormTime = FromTimeComboBox.SelectedIndex,
                    IdYearAdd = YearAddComboBox.SelectedIndex,
                    IdGroup = NamGroupComboBox.SelectedIndex

                };
                db.context.Students.Add(studObj);
                db.context.SaveChanges();
                MessageBox.Show("Данные успешно добавлениы!", "Увидомление", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(new SigInPage());
            }
            catch
            {
                MessageBox.Show("Ошибка при добавление данных!", "Увидомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

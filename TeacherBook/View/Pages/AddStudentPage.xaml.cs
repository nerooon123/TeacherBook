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
            ProfessionComboBox.ItemsSource = db.context.Professions.ToList();
            ProfessionComboBox.DisplayMemberPath = "NameProfession";

            YearAddComboBox.ItemsSource = db.context.YearAdd.ToList();
            YearAddComboBox.DisplayMemberPath = "Year";

            FormTimeComboBox.ItemsSource = db.context.FormTime.ToList();
            FormTimeComboBox.DisplayMemberPath = "Name";

            NamGroupComboBox.ItemsSource = db.context.Groups.ToList();
            NamGroupComboBox.DisplayMemberPath = "NameGroup";
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
                    IdProfession = 1 + ProfessionComboBox.SelectedIndex,
                    IdFormTime = 1 + FormTimeComboBox.SelectedIndex,
                    IdYearAdd = 1 + YearAddComboBox.SelectedIndex,
                    IdGroup = 1 + NamGroupComboBox.SelectedIndex

                };
                db.context.Students.Add(studObj);
                db.context.SaveChanges();
                MessageBox.Show("Данные успешно добавлениы!", "Увидомление", MessageBoxButton.OK, MessageBoxImage.Information);
                this.NavigationService.Navigate(new MenuPage());
            }
            catch
            {
                MessageBox.Show("Ошибка при добавление данных!", "Увидомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

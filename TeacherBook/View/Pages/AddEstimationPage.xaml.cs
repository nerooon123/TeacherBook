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
    /// Логика взаимодействия для AddEstimationPage.xaml
    /// </summary>
    public partial class AddEstimationPage : Page
    {
        Core db = new Core();
        public AddEstimationPage()
        {
            InitializeComponent();

            GroupNameComboBox.ItemsSource = db.context.Groups.ToList();
            GroupNameComboBox.DisplayMemberPath = "NameGroup";

            StudentNameComboBox.ItemsSource = db.context.Students.ToList();
            StudentNameComboBox.DisplayMemberPath = "FiestName";

            DisciplineComboBox.ItemsSource = db.context.Subjects.ToList();
            DisciplineComboBox.DisplayMemberPath = "NameSubject";
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Journals jourObj = new Journals()
                {
                    IdStudent = 1 +StudentNameComboBox.SelectedIndex,
                    IdGroup = 1 +GroupNameComboBox.SelectedIndex,
                    IdSubject = 1 + DisciplineComboBox.SelectedIndex,
                    Evaluation = Convert.ToInt32(Evaluation.Text)

                };
                db.context.Journals.Add(jourObj);

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

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
    /// Логика взаимодействия для DellStudentPage.xaml
    /// </summary>
    public partial class DellStudentPage : Page
    {
        Core db = new Core();
        public DellStudentPage()
        {
            InitializeComponent();
            GroupNameComboBox.ItemsSource = db.context.Groups.ToList();
            GroupNameComboBox.DisplayMemberPath = "NameGroup";
            GroupNameComboBox.SelectedValuePath = "IdGroup";
            GroupDataGrid.ItemsSource= db.context.Students.ToList();

        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                var item = GroupDataGrid.SelectedItem as Students;

                //проверка того, что пользователь выбрал строки для удаления

                if (item == null)

                {

                    MessageBox.Show("Вы не выбрали ни одной строки");

                    return;

                }

                else
                {

                    //выполним удаление только в том случае, если пользователь даст согласие на удаление

                    MessageBoxResult result = MessageBox.Show("Вы уверены, что хотите удалить строку?", "Удаление", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {

                        //удаляем выбранную строку

                        db.context.Students.Remove(item);

                        db.context.SaveChanges();

                        MessageBox.Show("Информация удалена");

                        //обновление DataGrid

                        GroupDataGrid.ItemsSource = db.context.Students.ToList();

                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Данные не удалены. ");
            }
        }

        private void GroupNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

            int obj = Convert.ToInt32(GroupNameComboBox.SelectedValue);

            GroupDataGrid.ItemsSource = db.context.Groups.Where(x => x.IdGroup == obj).ToList();
        }
    }
}

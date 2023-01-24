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
    /// Логика взаимодействия для ConstructEstimationPage.xaml
    /// </summary>
    public partial class ConstructEstimationPage : Page
    {
        public ConstructEstimationPage()
        {
            InitializeComponent();
        }

        private void GroupNameComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int obj = Convert.ToInt32(GroupNameComboBox.SelectedValue);

            GroupDataGrid.ItemsSource = db.context.Groups.Where(x => x.IdGroup == obj).ToList();
        }
    }
}

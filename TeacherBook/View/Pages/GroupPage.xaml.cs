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
    /// Логика взаимодействия для GroupPage.xaml
    /// </summary>
    public partial class GroupPage : Page
    {
        Core db = new Core();
        public GroupPage()
        {
            InitializeComponent();
            //GroupData.ItemsSource = db.context.Students.ToList();
            GroupName.ItemsSource = db.context.Groups.ToList();
            GroupName.DisplayMemberPath = "NameGroup";
            var query =
            from Students in db.context.Students
            select new { Students.IdStudent, Students.FiestName, Students.LastName, Students.PatronomicName, Students.Professions.NameProfession, Students.FormTime.Name, Students.Groups.NameGroup, Students.YearAdd.Year};

            GroupData.ItemsSource = query.ToList();
            
        }

        private void GroupName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GroupName.SelectedIndex == 0)
            {
                var query =
                from Students in db.context.Students
                select new { Students.IdStudent, Students.FiestName, Students.LastName, Students.PatronomicName, Students.Professions.NameProfession, Students.FormTime.Name, Students.Groups.NameGroup, Students.YearAdd.Year };

                GroupData.ItemsSource = query.ToList().OrderBy(p => p.NameGroup);
            }

        }
    }
}

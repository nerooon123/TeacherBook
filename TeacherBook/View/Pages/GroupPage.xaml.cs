using Microsoft.Office.Interop.Excel;
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
using Excel = Microsoft.Office.Interop.Excel;

namespace TeacherBook.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для GroupPage.xaml
    /// </summary>
    public partial class GroupPage : System.Windows.Controls.Page
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
            GroupData.SelectedValuePath = "IdGroup";

            int idGroup = Convert.ToInt32(GroupData.SelectedValue);

            var query =
                from Students in db.context.Students
                where Students.IdGroup == idGroup
                select new { Students.IdStudent, Students.FiestName, Students.LastName, Students.PatronomicName, Students.Professions.NameProfession, Students.FormTime.Name, Students.Groups.NameGroup, Students.YearAdd.Year };

            GroupData.ItemsSource = query.ToList();



            // GroupData.ItemsSource = db.context.Students.Where(x => x.IdGroup == idGroup).ToList();



        }

        private void SaveExcel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application excel = new Excel.Application();

            excel.Visible = true;
            Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
            Worksheet sheet1 = (Worksheet)workbook.Sheets[1];
            Range range;
            Range myRange;
            for (int i = 1; i < GroupData.Columns.Count; i++)
            {
                range = (Range)sheet1.Cells[1, i + 1];
                sheet1.Cells[1, i + 1].Font.Bold = true;
                range.Value = GroupData.Columns[i].Header;

                for (int j = 0; j < GroupData.Items.Count; j++)
                {
                    TextBlock b = GroupData.Columns[i].GetCellContent(GroupData.Items[j]) as TextBlock;
                    myRange = sheet1.Cells[j + 2, i + 1];
                    myRange.Value = b.Text;
                }
            }
        }
    }
}

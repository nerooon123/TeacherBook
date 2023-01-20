using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.IO;
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
using Word = Microsoft.Office.Interop.Word;


namespace TeacherBook.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для GroupPage.xaml
    /// </summary>
    public partial class GroupPage : System.Windows.Controls.Page
    {
        Core db = new Core();
        // arrayStudents
        public GroupPage()
        {
            InitializeComponent();
            //GroupData.ItemsSource = db.context.Students.ToList();
            GroupName.ItemsSource = db.context.Groups.ToList();
            GroupName.DisplayMemberPath = "NameGroup";
            GroupData.SelectedValuePath = "IdGroup";
            var query =
            from Students in db.context.Students
            select new { Students.IdStudent, Students.FiestName, Students.LastName, Students.PatronomicName, Students.Professions.NameProfession, Students.FormTime.Name, Students.Groups.NameGroup, Students.YearAdd.Year};

            GroupData.ItemsSource = query.ToList();
            
        }

        private void GroupName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

            int idGroup = Convert.ToInt32(GroupData.SelectedValue);

            var query =
                from Students in db.context.Students
                where Students.IdGroup == idGroup
                select new { Students.IdStudent, Students.FiestName, Students.LastName, Students.PatronomicName, Students.Professions.NameProfession, Students.FormTime.Name, Students.Groups.NameGroup, Students.YearAdd.Year };

            GroupData.ItemsSource = query.ToList();




            //arrayStudents = db.context.Students.Where(x => x.IdGroup == idGroup).ToList();
            //GroupData.ItemsSource = arrayStudents;



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

        private void SaveWord_Click(object sender, RoutedEventArgs e)
        {
            Word.Application aplication = new Word.Application();
            Word.Document document = aplication.Documents.Add();
            Word.Paragraph titleParagraph = document.Paragraphs.Add();
            Word.Range titleRange = titleParagraph.Range;
            titleRange.Text = "МИНИСТЕРСТВО БРАЗОВАНИЯ И МОЛОДЕЖНОЙ ПОЛИТИКИ СВЕРДЛОВСКОЙ ОБЛАСТИ ГОСУДАРСТВЕННОЕ АВТОНОМНОЕ ПРОФФЕСИАНАЛЬНОЕ ОБРАЗОВАТЕЛЬНОЕ УЧРЕЖДЕНИЕ СВЕРДЛОВСКОЙ ОБЛАСТИ";
            //выравнивание по центру
            titleRange.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            //перенос строки
            titleRange.InsertParagraphAfter();
            Word.Paragraph titleParagraphWb = document.Paragraphs.Add();
            Word.Range titleRangeWb = titleParagraphWb.Range;
            titleRangeWb.Text = "«ЕКАТЕРИНБУРГСКИЙ МОНТАЖНЫЙ КОЛЛЕДЖ»";
            titleRangeWb.Bold = 3;
            titleRangeWb.InsertParagraphAfter();
            //таблица
            Word.Paragraph TableParagraph = document.Paragraphs.Add();
            Word.Range tableRange = TableParagraph.Range;
            Word.Table titleTable = document.Tables.Add(tableRange, 1, 3);
            Word.Range cellRange;
            cellRange = titleTable.Cell(1, 1).Range;
            cellRange.Text = "«_____» ";
            cellRange = titleTable.Cell(1, 2).Range;
            cellRange.Text = "_________";
            cellRange = titleTable.Cell(1, 3).Range;
            cellRange.Text = "20_____ Г.";

            Word.Paragraph titleParagraphWbc = document.Paragraphs.Add();
            Word.Range titleRangeWbc = titleParagraphWbc.Range;
            titleRangeWbc.Text = "Группа №: \n Преподаватель: ";
            titleRangeWbc.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;


            //таблица
            Word.Paragraph TableParagraph2 = document.Paragraphs.Add();
            Word.Range tableRange2 = TableParagraph2.Range;
            Word.Table titleTable2 = document.Tables.Add(tableRange2, 14, 3);
            Word.Range cellRange2;
            cellRange2 = titleTable2.Cell(1, 1).Range;
            cellRange2.Text = "№ п/п";
            cellRange2 = titleTable2.Cell(1, 2).Range;
            cellRange2.Text = "Фамилия, имя, отчество слушателя";
            cellRange2 = titleTable2.Cell(1, 3).Range;
            cellRange2.Text = "Результат аттестации";
            for (int i = 2; i < 14; i++)
            {
                cellRange2 = titleTable2.Cell(i, 1).Range;
                cellRange2.Text = Convert.ToString(i - 1);
            }
            //for (int i = 2; i < ; i++)
            //{
            //    cellRange2 = titleTable2.Cell(i, 2).Range;
            //    cellRange2.Text = Convert.ToString(i - 1);
            //}



            aplication.Visible = true;

            document.SaveAs2($"{Directory.GetCurrentDirectory()}\\Docs\\Test.docx");
            document.SaveAs2($"{Directory.GetCurrentDirectory()}\\Docs\\Test.pdf", Word.WdExportFormat.wdExportFormatPDF);


        }
    }
}

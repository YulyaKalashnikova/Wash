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
using System.Windows.Shapes;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Wash.Properties;

namespace Wash
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private int _tag = 0;
        public AdminWindow()
        {
            InitializeComponent();
            Title = $"{Helper.s_staff.FullName}. - \"Постирушки\"";

        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _tag = Convert.ToInt32((sender as Border).Tag);
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddEmpoyeeWindow addEmpoyee = new AddEmpoyeeWindow();
            addEmpoyee.ShowDialog();
        }

        private void BtnReport_Click(object sender, RoutedEventArgs e)
        {
            switch (_tag)
            {
                case 1:
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.FileName = "report";
                    saveFileDialog.Filter = "Pdf files |.pdf";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        Word.Application app = new Word.Application();
                        Word.Document doc = app.Documents.Add();
                        var date = Settings.Default.DateTimeFinish.Date;
                        var services = Helper.GetContext().Services
                            .Include(x => x.Machine)
                            .Include(x => x.Powder)
                            .Include(x => x.Staff)
                            .Include(x => x.Drying).ToList()
                            .Where(x => x.DateStart.Year == date.Year
                        && x.DateStart.Month == date.Month
                        && x.DateStart.Day == date.Day).ToList();
                        if (!services.Any())
                        {
                            MessageBox.Show("Нет данных");
                            return;
                        }
                        Word.Paragraph paragraph = doc.Paragraphs.Add();
                        Word.Range range = paragraph.Range;
                        Word.Table table = doc.Tables.Add(range, services.Count()+1, 6);
                        Word.Range cellRange;
                        cellRange = table.Cell(1, 1).Range;
                        cellRange.Text = "Код";
                        cellRange = table.Cell(1, 2).Range;
                        cellRange.Text = "Стиральная машина";
                        cellRange = table.Cell(1, 3).Range;
                        cellRange.Text = "Порошок";
                        cellRange = table.Cell(1, 4).Range;
                        cellRange.Text = "Сушка";
                        cellRange = table.Cell(1, 5).Range;
                        cellRange.Text = "Сотрудник";
                        cellRange = table.Cell(1, 6).Range;
                        cellRange.Text = "Стоимость";
                        for (int i = 0; i < services.Count(); i++)
                        {
                            int j = i + 2;
                            cellRange = table.Cell(j, 1).Range;
                            cellRange.Text = services[i].Code;

                            cellRange = table.Cell(j, 2).Range;
                            cellRange.Text = services[i].Machine.Name;

                            cellRange = table.Cell(j, 3).Range;
                            cellRange.Text = services[i].Powder.Name;

                            cellRange = table.Cell(j, 4).Range;
                            cellRange.Text = services[i].Drying.Name;

                            cellRange = table.Cell(j, 5).Range;
                            cellRange.Text = services[i].Staff.FullName;

                            var amount = services[i].Machine.Price + services[i].Powder.Price + services[i].Drying.Price;

                            cellRange = table.Cell(j, 6).Range;
                            cellRange.Text = amount.ToString();
                        }

                        doc.SaveAs2(saveFileDialog.FileName, Word.WdSaveFormat.wdFormatPDF);
                        app.Quit();
                        MessageBox.Show("Отчёт создан!");
                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        private void ThisWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.Default.DateTimeFinish = DateTime.Now;
            Settings.Default.Save();
        }
    }
}

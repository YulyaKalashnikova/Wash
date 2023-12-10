using Microsoft.Win32;
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
using Wash.Properties;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.EntityFrameworkCore;

namespace Wash
{
    /// <summary>
    /// Логика взаимодействия для WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        private int _tag = 0;
        public WorkerWindow()
        {
            InitializeComponent();
            Load();
            Title = $"{Helper.s_staff.FullName}. - \"Постирушки\"";
        }

        private void Load()
        {
            var services = Helper.GetContext().Services
                .Include(x => x.Machine)
                .Include(x => x.Powder)
                .Include(x => x.Staff)
                .Include(x => x.Drying)
                .ToList();
            ActiveWashGrid.ItemsSource = services.Where(x => !x.IsStatus.HasValue).ToList();
            IsNoActiveWashGrid.ItemsSource = services.Where(x => !x.IsStatus.Value && x.IsStatus.Value).ToList();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddWashWindow addWash = new AddWashWindow();
            addWash.ShowDialog();
            Load();
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
                        var services = Helper.GetContext().Services.ToList().Where(x => x.DateStart.Year == date.Year
                        && x.DateStart.Month == date.Month
                        && x.DateStart.Day == date.Day).Count();
                        Word.Paragraph paragraph = doc.Paragraphs.Add();
                        Word.Range range = paragraph.Range;
                        range.Text = $"Количество стирок за смену: {services}";
                        doc.SaveAs2(saveFileDialog.FileName, Word.WdSaveFormat.wdFormatPDF);
                        app.Quit();
                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _tag = Convert.ToInt32((sender as Border).Tag);
        }

        private void ChangeStatus_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((sender as DataGrid).SelectedItem is Service service)
            {
                ChangeStatusWindow changeStatusWindow = new ChangeStatusWindow(service);
                changeStatusWindow.ShowDialog();
                Load();
            }

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Settings.Default.DateTimeFinish = DateTime.Now;
            Settings.Default.Save();
        }
    }
}

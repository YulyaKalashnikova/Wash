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

namespace Wash
{
    /// <summary>
    /// Логика взаимодействия для ChangeStatusWindow.xaml
    /// </summary>
    public partial class ChangeStatusWindow : Window
    {
        private List<string> _statuses = new List<string>() { "Выберите статус", "Выдан", "Готов" };
        private Service Service { get; set; }
        public ChangeStatusWindow(Service service)
        {
            InitializeComponent();
            Service = service;
            CmbStatuses.ItemsSource = _statuses;
            Title = $"{Helper.s_staff.FullName}. - \"Постирушки\"";
            if (service.IsStatus.HasValue)
            {
                CmbStatuses.SelectedIndex = service.IsStatus == true ? 1 : 2;
            }
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (CmbStatuses.SelectedIndex != 0)
            {
                if (Service.IsStatus.HasValue)
                {
                    if (Service.IsStatus.Value && CmbStatuses.SelectedIndex != 2)
                    {
                        MessageBox.Show("Нельзя сменить статус выдан на готов!");
                        return;
                    }

                }
                else
                {
                    if (CmbStatuses.SelectedIndex != 2)
                    {
                        MessageBox.Show("Только выбрать готов!");
                        return;
                    }
                }
                Service.IsStatus = CmbStatuses.SelectedIndex == 1 ? true : false;
                Helper.GetContext().SaveChanges();
            }
        }
    }
}

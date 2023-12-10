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

namespace Wash
{
    /// <summary>
    /// Логика взаимодействия для AddWashWindow.xaml
    /// </summary>
    public partial class AddWashWindow : Window
    {
        public List<Powder> Powders = new List<Powder>();
        public List<Machine> Machines = new List<Machine>();
        public AddWashWindow()
        {
            InitializeComponent();
            LoadData();
            Load();
        }
        private void LoadData()
        {
            Powders = Helper.GetContext().Powders.ToList();
            Powders.Insert(0, new Powder() { Id = 0, Name = "Наименование порошка" });
            Machines = Helper.GetContext().WashingMachines.ToList();
            Machines.Insert(0, new Machine() { Id = 0, Name = "Номер стиральной машины" });
        }

        private void Load()
        {
            CmbPowders.ItemsSource = Powders;
            CmbMachines.ItemsSource = Machines;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var powder = CmbPowders.SelectedItem as Powder;
            var machine = CmbMachines.SelectedItem as Machine;
            if (powder.Id == 0 || machine.Id == 0)
            {
                MessageBox.Show("Выберите данные из выпадающего списка!");
                return;
            }
            var dryingId = CbDrying.IsChecked == true ? 1 : 2;
            var settingCode = Settings.Default.Code;
            var date = DateTime.Now;
            var code = $"{settingCode:0000}-{date.Day}-{date.Month}-{date.Year}";
            Service service = new Service()
            {
                DryingId = dryingId,
                IsStatus = true,
                MachineId = machine.Id,
                PowderId = powder.Id,
                StaffId = Helper.s_staff.Id,
                Code = code,
            };
            Helper.GetContext().Services.Add(service);
            Helper.GetContext().SaveChanges();
            BtnPrint.IsEnabled = true;
            Settings.Default.Code += 1;
            Settings.Default.Save();
        }

        private void BtnPrint_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Чек распечатан!");
            Close();
        }
    }
}
